using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoRenderer : MonoBehaviour
{
    private float TimeBetweenSpawns;
    public float StartTimeBetweenSpawns;

    public GameObject bubble;

    void Update()
    {
        if(TimeBetweenSpawns <= 0)
        {
            GameObject instance = Instantiate(bubble, transform.position, Quaternion.identity);
            Destroy(instance, 1f);
            TimeBetweenSpawns = StartTimeBetweenSpawns;
        }
        else
        {
            TimeBetweenSpawns -= Time.deltaTime;
        }
    }
}
