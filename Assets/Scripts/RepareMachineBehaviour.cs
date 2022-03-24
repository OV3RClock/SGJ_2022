using Managers;
using UnityEngine;

public class RepareMachineBehaviour : ActionObject
{
    [SerializeField] private Animator UIRepare;
    
    
    public override void PerformAction()
    {
        UIRepare.SetBool("show", true);
        AudioManager.Instance.Play("SFXOnModifEnter");
        AbilitiesManager.instance.OnRepareMachine = true;
    }

    public override void CancelAction()
    {
        if (UIRepare.GetBool("show"))
            AudioManager.Instance.Play("SFXOnModifQuit");
        UIRepare.SetBool("show", false);
        AbilitiesManager.instance.OnRepareMachine = false;
    }
}
