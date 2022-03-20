using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AbilitiesManager : MonoBehaviour
    {
        public static AbilitiesManager instance;

        private HashSet<EAbilities> unlockedAbilities = new HashSet<EAbilities>();
        private List<EAbilities> activeAbilities = new List<EAbilities>();
        [SerializeField] private int nbMaxAbilities = 3;

        public static Action abilitiesManagerEvent;


        private void Awake()
        {
            /*
            unlockedAbilities.Add(EAbilities.RED);
            unlockedAbilities.Add(EAbilities.BLUR);
            */
            AudioManager.Instance.Play("FullGameTheme");
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

        public void ActivateAbility(EAbilities ability)
        {
            if (activeAbilities.Contains(ability))
            {
                activeAbilities.Remove(ability);
                abilitiesManagerEvent();
            }
            else if (activeAbilities.Count < nbMaxAbilities)
            {
                activeAbilities.Add(ability);
                abilitiesManagerEvent();
            }
        }

        public bool IsAbilityActive(EAbilities ability)
        {
            return (activeAbilities.Contains(ability));
        }

        public void UnlockAbility(EAbilities ability)
        {
            unlockedAbilities.Add(ability);
            abilitiesManagerEvent();
            /*try
            {
                
            }
            catch (Exception)
            {

            }*/

        }

        public bool IsAbilityUnlocked(EAbilities ability)
        {
            return (unlockedAbilities.Contains(ability));
        }

        public bool HadAtLeastOneAbility()
        {
            return !(unlockedAbilities.Count == 0);
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