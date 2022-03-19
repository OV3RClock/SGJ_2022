using Managers;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBtn : MonoBehaviour
{
    [SerializeField] private EAbilities abilityId;
    [SerializeField] private KeyCode key;

    [SerializeField] private Image image;


    private void Awake()
    {
        AbilitiesManager.abilitiesManagerEvent += notify;
    }

    private void OnDestroy()
    {
        AbilitiesManager.abilitiesManagerEvent -= notify;
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            AbilitiesManager.instance.ActivateAbility(abilityId);
        }
    }

    public void notify()
    {
        if (AbilitiesManager.instance.IsAbilityActive(abilityId))
        {
            image.color = Color.blue;
        }
        else
        {
            image.color = Color.white;
        }
    }
}
