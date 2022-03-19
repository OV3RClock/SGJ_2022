using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoRenderer : MonoBehaviour
{
    public float TimeBetweenSpawns;
    public float StartTimeBetweenSpawns;

    public GameObject bubble;

    void Update()
    {
        if(TimeBetweenSpawns <= 0)
        {
            Instantiate(bubble, transform.position, Quaternion.identity);
            TimeBetweenSpawns = StartTimeBetweenSpawns;
        }
        else
        {
            TimeBetweenSpawns -= Time.deltaTime;
        }
    }
}
