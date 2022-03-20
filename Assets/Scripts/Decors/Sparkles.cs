using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkles : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particleSystem1;
    [SerializeField]
    private ParticleSystem particleSystem2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateSparkles());
    }

    private IEnumerator GenerateSparkles()
    {
        particleSystem1.Play();
        particleSystem2.Play();
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        StartCoroutine(GenerateSparkles());
    }
}
