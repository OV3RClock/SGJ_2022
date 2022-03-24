using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehavior : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform target;
    private Quaternion neededRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        neededRotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, player.rotationSpeed * Time.deltaTime);
    }
}
