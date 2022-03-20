using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        AudioManager.Instance.Play("MenuMusic");
    }

    public void PlayButton()
    {
        AudioManager.Instance.Play("UIConfirm");
        AudioManager.Instance.Stop("MenuMusic");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        AudioManager.Instance.Play("UIConfirm");
        Application.Quit();
    }

    public void CreditsButton()
    {
        AudioManager.Instance.Play("UIConfirm");
    }

    public void BackButton()
    {
        AudioManager.Instance.Play("UIBack");
    }
}
