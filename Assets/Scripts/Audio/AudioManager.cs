using UnityEngine.Audio;
using UnityEngine;
using System;
using Managers;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    private string _currentMusic;

    public static AudioManager Instance;

    void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        #endregion

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;

            if (s.AbilityDependant)
            {
                s.Source.Play();
                s.Source.volume = 0;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found !");
            return;
        }
        s.Source.Play();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found !");
            return;
        }
        s.Source.Play();
        _currentMusic = name;
    }

    public void PlayMusic(EAbilities ability)
    {
        Sound s = Array.Find(Sounds, sound => sound.Ability == ability);
        if (s == null)
        {
            Debug.LogWarning("Sound/ability " + ability + " not found !");
            return;
        }
        StartCoroutine(StartFade(s.Source, 1, 0.8f));
    }
    public void StopMusic(EAbilities ability)
    {
        Sound s = Array.Find(Sounds, sound => sound.Ability == ability);
        if (s == null)
        {
            Debug.LogWarning("Sound/ability " + ability + " not found !");
            return;
        }
        StartCoroutine(StartFade(s.Source, 1, 0));
    }

    public IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.Source.Pause();
    }

    public void Resume(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        s.Source.UnPause();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if(s == null)
            Debug.LogError("Sound not found : " + name);
        else
        s.Source.Stop();

        _currentMusic = null;
    }

    public bool isPlaying(string name)
    {
        return name == _currentMusic;
    }
}
