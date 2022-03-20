using Managers;
using System;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text TMPtext;
        [SerializeField] private float offset = 2;
        
        private ActionObject objectToInteractWith = null;
        public bool available = false;


        private void Start()
        {
            TMPtext.gameObject.SetActive(available);
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