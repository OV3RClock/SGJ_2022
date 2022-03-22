using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReseauNeuroneUI : MonoBehaviour
{
    [SerializeField] private EAbilities abilityId;
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

    private void SetUnlocked(bool unlocked)
    {
        this.unlocked = unlocked;
    }

    private void SetEnabled(bool enabled)
    {
        if (enabled)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.white/2;
        }
    }

    public void notify()
    {
        if (AbilitiesManager.instance.IsAbilityUnlocked(abilityId))
        {
            SetUnlocked(true);
            SetEnabled(true);
        }
    }
}
