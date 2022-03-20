using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAS : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator animatorRoue;
    // Start is called before the first frame update
    void Start()
    {
        OpenSAS();
    }

    public void OpenSAS()
    {
        animator.SetTrigger("open");
        animatorRoue.SetTrigger("open");
    }
}
