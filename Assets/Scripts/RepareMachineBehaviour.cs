using UnityEngine;

public class RepareMachineBehaviour : ActionObject
{
    [SerializeField] private GameObject UIRepare;
    
    
    public override void PerformAction()
    {
        UIRepare.SetActive(true);
    }

    public override void CancelAction()
    {
        UIRepare.SetActive(false);
    }
}
