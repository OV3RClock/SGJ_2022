using Managers;
using UnityEngine;

public class RepareMachineBehaviour : ActionObject
{
    [SerializeField] private Animator UIRepare;
    
    
    public override void PerformAction()
    {
        UIRepare.SetBool("show", true);
        AbilitiesManager.instance.OnRepareMachine = true;
    }

    public override void CancelAction()
    {
        UIRepare.SetBool("show", false);
        AbilitiesManager.instance.OnRepareMachine = false;
    }
}
