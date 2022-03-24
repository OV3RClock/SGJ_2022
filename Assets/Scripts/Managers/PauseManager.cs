using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool pause;
    [SerializeField] private GameObject pausePanel, rouge, batonnet, contraste, mouvement, nettete, anticipation;
    [SerializeField] private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            pause = !pause;
            ManagePauseMenu();
        }
    }

    private void ManagePauseMenu()
    {
        if (pause)
            AudioManager.Instance.Play("SFXPopUp");
        else
            AudioManager.Instance.Play("UIBack");

        pausePanel.SetActive(pause);
        player.Stop(pause);

        rouge.SetActive(AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.RED));
        batonnet.SetActive(AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.NIGHT_VISION));
        contraste.SetActive(AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.CONTRAST));
        mouvement.SetActive(AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.MOVEMENT));
        nettete.SetActive(AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.BLUR));
        anticipation.SetActive(AbilitiesManager.instance.IsAbilityUnlocked(EAbilities.ANTICIPATION));
    }

    public void CloseMenuPause()
    {
        pause = false;
        ManagePauseMenu();
    }
    public void MainMenuButton()
    {
        AudioManager.Instance.StopAllMusics();
        SceneManager.LoadScene(0);
    }
}
