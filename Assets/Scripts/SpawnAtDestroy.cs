using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAtDestroy : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    private void OnDestroy()
    {

        Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
    }
}
