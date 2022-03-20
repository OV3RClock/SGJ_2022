using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBtn : MonoBehaviour
{
    [SerializeField] private EAbilities abilityId;
    [SerializeField] private KeyCode key;

    [SerializeField] private Image image;
    private bool unlocked = false;


    private void Start()
    {
        SetUnlocked(AbilitiesManager.instance.IsAbilityUnlocked(abilityId));
        image.color = Color.white / 2;
    }

    private void OnEnable()
    {
        AbilitiesManager.abilitiesManagerEvent += notify;
    }

    private void OnDestroy()
    {
        AbilitiesManager.abilitiesManagerEvent -= notify;
    }

    void Update()
    {
        if (!unlocked) return;
        
        if (Input.GetKeyDown(key))
        {
            AbilitiesManager.instance.ActivateAbility(abilityId);
        }
    }

    private void SetUnlocked(bool unlocked)
    {
        this.unlocked = unlocked;
        image.enabled = unlocked;
    }

    private void SetEnabled(bool enabled)
    {
        if (enabled)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.white / 2;
        }
    }

    public void notify()
    {
        if (AbilitiesManager.instance.IsAbilityUnlocked(abilityId))
        {
            SetUnlocked(true);
        }
        SetEnabled(AbilitiesManager.instance.IsAbilityActive(abilityId));
    }
}
