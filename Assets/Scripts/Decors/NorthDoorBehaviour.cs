using Managers;
using UnityEngine;

public class NorthDoorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform doorStop;
    [SerializeField] private float speed;
    [SerializeField] private bool isLocked;

    private Vector3 targetPos;
    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            AudioManager.Instance.Play("SFXDoor");
            targetPos = doorStop.position;
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
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
        if (AbilitiesManager.instance.IsAbilityActive(EAbilities.RED))
            isLocked = false;
        else
            isLocked = true;

        if (isActive && !isLocked)
            ActivateDoor();
    }

    public void SetIsLocked(bool unlock)
    {
        isLocked = unlock;
    }
}