using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private TextMeshProUGUI tmpText;
    [SerializeField] private string[] strings;

    [SerializeField] private float delay;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        //player.Stop(true);
        StartCoroutine(BlinkPoint());
    }
    private IEnumerator BlinkPoint()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
                tmpText.text += ".";
            else
                tmpText.text = tmpText.text.Substring(0,tmpText.text.Length-1);
            yield return new WaitForSeconds(delay*2);
        }
        StartCoroutine(PlayText());
    }
    private IEnumerator PlayText()
    {
        if (strings.Length <= currentIndex) yield return null;

        string story = strings[currentIndex];
        foreach (char c in story)
        {
            tmpText.text += c;
            yield return new WaitForSeconds(delay);
        }
        tmpText.text += "\n\n";
        currentIndex++;
        StartCoroutine(BlinkPoint());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
