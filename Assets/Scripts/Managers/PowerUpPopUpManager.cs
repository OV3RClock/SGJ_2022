using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class PowerUpPopUpManager : MonoBehaviour
    {
        public static PowerUpPopUpManager instance;

        [SerializeField] private GameObject popPanel, rouge, batonnet, contraste, mouvement, nettete, anticipation, reseauUP, reseauUP2;
        [SerializeField] private PlayerController player;

        // Start is called before the first frame update
        void Start()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            popPanel.SetActive(false);
        }

        public void ShowPopUp(EAbilities ability)
        {
            popPanel.SetActive(true);
            player.Stop(true);

            rouge.SetActive(ability == EAbilities.RED);
            batonnet.SetActive(ability == EAbilities.NIGHT_VISION);
            contraste.SetActive(ability == EAbilities.CONTRAST);
            mouvement.SetActive(ability == EAbilities.MOVEMENT);
            nettete.SetActive(ability == EAbilities.BLUR);
            anticipation.SetActive(ability == EAbilities.ANTICIPATION);
            reseauUP.SetActive(ability == EAbilities.RESEAU1);
            reseauUP2.SetActive(ability == EAbilities.RESEAU2);
        }

        private void Update()
        {
            if (popPanel.activeSelf)
                if (Input.GetKeyDown(KeyCode.KeypadEnter))
                    ClosePopup();
        }

        public void ClosePopup()
        {
            popPanel.SetActive(false);
            player.Stop(false);
            AbilitiesManager.instance.animatorRepareStation.SetTrigger("show");
            StartCoroutine(AbilitiesManager.instance.ResetTrigger());
        }
    }
}
