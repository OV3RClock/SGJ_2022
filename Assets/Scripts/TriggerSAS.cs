using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSAS : MonoBehaviour
{
    public SAS sas;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            sas.OpenSAS();
        }
    }
}