using Managers;
using System;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI TMPtext;
        
        private ActionObject objectToInteractWith = null;
        public bool available = false;

        [SerializeField] private KeyCode InteractKey, InteractKey2, InteractKey3;

        private void Start()
        {
            TMPtext.gameObject.SetActive(available);
        }

        private void Update()
        {
            if (!available) return;

            if (Input.GetKeyDown(InteractKey) || Input.GetKeyDown(InteractKey2) || Input.GetKeyDown(InteractKey3))
            {
                if (objectToInteractWith != null)
                {
                    EnableInteractionText(false);
                    objectToInteractWith.PerformAction();
                }
            }
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
            if (!AbilitiesManager.instance.HadAtLeastOneAbility()) return;

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
            TMPtext.gameObject.SetActive(enabled);
        }
    }
}