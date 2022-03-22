using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (AbilitiesManager.instance != null)
            AbilitiesManager.instance.ResetStates();
    }
}
