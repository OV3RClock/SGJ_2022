using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAfterDelay : MonoBehaviour
{
    [SerializeField] private float delay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideGO());
    }

    private IEnumerator HideGO()
    {
        yield return new WaitForSeconds(delay);
        foreach (Animator animator in GetComponentsInChildren<Animator>())
        {
            animator.SetBool("show", false);
        }
    }
}
