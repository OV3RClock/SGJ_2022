using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
