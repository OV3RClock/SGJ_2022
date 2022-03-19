using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Transform doorStop;
    [SerializeField] private float speed;
    [SerializeField] private bool isLocked;
    
    private Vector3 targetPos;
    private bool isOpened = false;
    private bool isActive = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            targetPos = doorStop.position;
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            targetPos = transform.position;
            isActive = true;
        }
    }

    private void ActivateDoor()
    {
        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(door.transform.position, targetPos) < 0.001f)
        {
            // Swap the position of the cylinder.
            targetPos *= -1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && !isLocked)
            ActivateDoor();
    }
}
