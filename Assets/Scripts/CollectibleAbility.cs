using Managers;
using UnityEngine;

public class CollectibleAbility : ActionObject
{
    [SerializeField] private EAbilities abilityID;


    public override void PerformAction()
    {
        AbilitiesManager.instance.UnlockAbility(abilityID);
        CancelAction();
    }

    public override void CancelAction()
    {
        
    }
}
