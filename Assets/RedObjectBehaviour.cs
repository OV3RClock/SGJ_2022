using System;
using Managers;
using UnityEngine;

public class RedObjectBehaviour : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteGB;
    [SerializeField] private Sprite spriteRed;


    private void Start()
    {
        notify();
    }

    public void notify()
    {
        if (AbilitiesManager.instance.IsAbilityActive(EAbilities.RED))
        {
            spriteRenderer.sprite = spriteRed;
        }
        else
        {
            spriteRenderer.sprite = spriteGB;
        }
    }
    
    private void OnEnable()
    {
        AbilitiesManager.abilitiesManagerEvent += notify;
    }
    
    private void OnDestroy()
    {
        AbilitiesManager.abilitiesManagerEvent -= notify;
    }
}
