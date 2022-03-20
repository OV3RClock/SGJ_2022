using Managers;
using UnityEngine;

public class CollectibleAbility : ActionObject
{
    [SerializeField] private EAbilities abilityID;
    [SerializeField] private Collider2D interactionCollider;


    public override void PerformAction()
    {
        AbilitiesManager.instance.UnlockAbility(abilityID);
        CancelAction();
    }

    public override void CancelAction()
    {
        interactionCollider.enabled = false;
    }
}
