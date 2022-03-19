using System;
using UnityEngine;

public abstract class ActionObject : MonoBehaviour
{
    public static event Action<ActionObject> OnActionObjectEntered;
    public static event Action<ActionObject> OnActionObjectExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            OnActionObjectEntered?.Invoke(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);
        if (layerName == "Player")
        {
            OnActionObjectExited?.Invoke(this);
            CancelAction();
        }
    }

    public abstract void PerformAction();
    public abstract void CancelAction();

}
