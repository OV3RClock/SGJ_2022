using System;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text TMPtext;
        [SerializeField] private float offset = 10;
        
        private ActionObject objectToInteractWith = null;
        private bool enabled = false;


        private void Start()
        {
            TMPtext.enabled = enabled;
        }

        private void Update()
        {
            if (!enabled) return;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (objectToInteractWith != null)
                {
                    objectToInteractWith.PerformAction();
                    EnableInteractionText(false);
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
            this.enabled = enabled;
            TMPtext.enabled = enabled;
        }
    }
}