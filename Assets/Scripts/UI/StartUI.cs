using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private string[] strings;
    [SerializeField] private float delay;
    [SerializeField] private Animator animatorButton;
    [SerializeField] private Animator animatorFade;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        animatorFade.SetBool("show", false);

        StartCoroutine(StartWrite());

    }

    private IEnumerator StartWrite()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(BlinkPoint());
    }

    private IEnumerator BlinkPoint()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
                tmpText.text += ".";
            else
                tmpText.text = tmpText.text.Substring(0, tmpText.text.Length - 1);
            yield return new WaitForSeconds(delay * 2);
        }
        StartCoroutine(PlayText());
    }
    private IEnumerator PlayText()
    {
        if (strings.Length <= currentIndex)
        {
            animatorButton.SetTrigger("show");
            yield return null;
        }
        else
        {
            string story = strings[currentIndex];
            foreach (char c in story)
            {
                tmpText.text += c;
                AudioManager.Instance.Play("UIMouseHover");
                yield return new WaitForSeconds(delay);
            }
            tmpText.text += "\n\n";
            currentIndex++;
            StartCoroutine(BlinkPoint());
        }
    }

    public void StartFade()
    {
        AudioManager.Instance.Play("UIConfirm");

        animatorFade.SetBool("show", true);
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        tmpText.text = "";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
