using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SAS : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator animatorRoue;


    public void OpenSAS()
    {
        StartCoroutine(SASopening());
    }

    private IEnumerator SASopening()
    {
        animator.SetTrigger("open");
        animatorRoue.SetTrigger("open");
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}
