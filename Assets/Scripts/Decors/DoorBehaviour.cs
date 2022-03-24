using Managers;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform doorStop;
    [SerializeField] private float speed;
    [SerializeField] private bool isLocked;
    [SerializeField] private bool UnlockWithRed;
    private bool unlockedWithRed;
    [SerializeField] private Light2D _light;
    [SerializeField] private Color LockedColor, UnlockedColor;

    private Vector3 targetPos;
    private bool isActive = false;
    private bool beingOpened = false;

    private void Start()
    {
        if (isLocked)
        {
            _light.color = LockedColor;
        }
        else
        {
            _light.color = UnlockedColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            if (!isLocked)
            {
                //TODO : Potentiellement enlever ce morceau de code qui declenche le son de la porte rouge
                if(!beingOpened && UnlockWithRed)
                    AudioManager.Instance.Play("SFXCodeSuccess");

                beingOpened = true;
                AudioManager.Instance.Play("SFXDoor");
            }

            targetPos = doorStop.position;
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            if (!isLocked)
                AudioManager.Instance.Play("SFXDoor");
            targetPos = transform.position;
            isActive = true;
        }
    }

    private void ActivateDoor()
    {

        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        door.position = Vector3.MoveTowards(door.position, targetPos, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(door.position, targetPos) < 0.001f)
        {
            // Swap the position of the cylinder.
            targetPos *= -1.0f;
            isActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UnlockWithRed && !unlockedWithRed)
        {
            if (AbilitiesManager.instance.IsAbilityActive(EAbilities.RED))
                SetIsLocked(false);
            else
                SetIsLocked(true);

            if (isActive && !isLocked)
            {
                ActivateDoor();
                unlockedWithRed = true;
                AbilitiesManager.instance.TriggerEvent();
            }
        }
        else
        {
            if (isActive && !isLocked)
                ActivateDoor();
        }
        if (!AbilitiesManager.instance.IsAbilityActive(EAbilities.RED) && isLocked)
        {
            _light.intensity = 0f;
        }
        else
        {
            _light.intensity = 1f;
        }
    }

    public void SetIsLocked(bool unlock)
    {
        isLocked = unlock;
        if (!isLocked)
        {
            _light.color = UnlockedColor;

        }
    }

    public bool IsLocked()
    {
        return isLocked;
    }
}
