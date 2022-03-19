using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOrga : MonoBehaviour
{
    [SerializeField]
    private float MinRange;
    [SerializeField]
    private float MaxRange;
    private float range;
    private Vector3 targetVector;
    // Start is called before the first frame update
    void Start()
    {
        range = Random.Range(MinRange, MaxRange);
        targetVector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0).normalized * range;
        Animator anim = GetComponent<Animator>();
        anim.speed = Random.Range(0.5f,2);
        anim.SetBool("horaire", Random.Range(0, 2) == 0 ? true : false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector);
    }
}
