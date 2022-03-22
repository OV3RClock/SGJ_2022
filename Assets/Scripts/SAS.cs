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
        AudioManager.Instance.Play("SFXSas");
        animator.SetTrigger("open");
        animatorRoue.SetTrigger("open");
    }

    public void EndGame()
    {
        AudioManager.Instance.Stop("FullGameTheme");
        SceneManager.LoadScene(0);
    }
}
