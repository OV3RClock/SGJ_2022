using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoRenderer : MonoBehaviour
{
    private float TimeBetweenSpawns;
    public float StartTimeBetweenSpawns;

    public GameObject Bubble;
    public Transform BubbleSpawnPoint;
    public Rigidbody2D Player;

    void Update()
    {
        if (Mathf.Abs(Player.velocity.x) > 0.5 || Mathf.Abs(Player.velocity.y) > 0.5)
        {
            if (TimeBetweenSpawns <= 0)
            {
                GameObject instance = Instantiate(Bubble, BubbleSpawnPoint.position, Quaternion.identity);
                Destroy(instance, 1f);
                TimeBetweenSpawns = StartTimeBetweenSpawns;
            }
            else
            {
                TimeBetweenSpawns -= Time.deltaTime;
            }
        }
    }
}
