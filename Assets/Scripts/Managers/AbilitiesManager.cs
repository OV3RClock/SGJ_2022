using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AbilitiesManager : MonoBehaviour
    {
        public static AbilitiesManager instance;
        [SerializeField]
        private HashSet<EAbilities> unlockedAbilities = new HashSet<EAbilities>();
        [SerializeField]
        private List<EAbilities> activeAbilities = new List<EAbilities>();
        [SerializeField] int nbMaxAbilities = 3;
        public Animator animatorRepareStation;

        public static Action abilitiesManagerEvent;

        public bool OnRepareMachine;


        private void Awake()
        {
            /*
            unlockedAbilities.Add(EAbilities.RED);
            unlockedAbilities.Add(EAbilities.BLUR);
            */
            AudioManager.Instance.Play("BaseGameTheme");
            AudioManager.Instance.Play("SFXPlayerWakeUp");
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void TriggerEvent()
        {
            abilitiesManagerEvent();
        }

        public void ActivateAbility(EAbilities ability)
        {
            if (activeAbilities.Contains(ability))
            {
                activeAbilities.Remove(ability);
                abilitiesManagerEvent();
                AudioManager.Instance.StopMusic(ability);
            }
            else if (activeAbilities.Count < nbMaxAbilities)
            {
                activeAbilities.Add(ability);
                abilitiesManagerEvent();
                AudioManager.Instance.PlayMusic(ability);
            }
        }

        public bool IsAbilityActive(EAbilities ability)
        {
            return (activeAbilities.Contains(ability));
        }

        public void UnlockAbility(EAbilities ability)
        {
            if (ability == EAbilities.RESEAU1 || ability == EAbilities.RESEAU2)
                nbMaxAbilities++;

            unlockedAbilities.Add(ability);
            abilitiesManagerEvent();
        }

        public bool IsAbilityUnlocked(EAbilities ability)
        {
            return (unlockedAbilities.Contains(ability));
        }

        public bool HadAtLeastOneAbility()
        {
            return !(unlockedAbilities.Count == 0);
        }

        public void ResetStates()
        {
            unlockedAbilities = new HashSet<EAbilities>();
            activeAbilities = new List<EAbilities>();
            nbMaxAbilities = 1;
        }

        public IEnumerator ResetTrigger()
        {
            yield return new WaitForSeconds(6);
            animatorRepareStation.ResetTrigger("show");
        }

    }

    public enum EAbilities
    {
        RED,
        NIGHT_VISION,
        CONTRAST,
        BLUR,
        MOVEMENT,
        ANTICIPATION,
        RESEAU1,
        RESEAU2
    }
}