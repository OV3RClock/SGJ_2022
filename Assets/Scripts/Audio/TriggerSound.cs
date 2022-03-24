using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField] private string Sound;

    public void Play()
    {
        AudioManager.Instance.Play(Sound);
    }
}
