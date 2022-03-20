using System;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text TMPtext;
        [SerializeField] private float offset = 2;
        
        private ActionObject objectToInteractWith = null;
        private bool available = false;


        private void Start()
        {
            TMPtext.enabled = available;
        }

        private void Update()
        {
            if (!available) return;
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (objectToInteractWith != null)
                {
                    EnableInteractionText(false);
                    objectToInteractWith.PerformAction();
                }
            }

            Vector2 transformPos = transform.position;
            transformPos.y += offset;
            Vector2 pos = Camera.main.WorldToScreenPoint(transformPos);
            TMPtext.transform.position = pos;
        }

        private void OnEnable()
        {
            ActionObject.OnActionObjectEntered += EnterInteraction;
            ActionObject.OnActionObjectExited += ExitInteraction;
        }

        private void OnDestroy()
        {
            ActionObject.OnActionObjectEntered -= EnterInteraction;
            ActionObject.OnActionObjectExited -= ExitInteraction;
        }

        public void EnterInteraction(ActionObject obj)
        {
            objectToInteractWith = obj;
            EnableInteractionText(true);
        }
        
        public void ExitInteraction(ActionObject obj)
        {
            objectToInteractWith = null;
            EnableInteractionText(false);
        }

        private void EnableInteractionText(bool enabled)
        {
            this.available = enabled;
            TMPtext.enabled = enabled;
        }
    }
}