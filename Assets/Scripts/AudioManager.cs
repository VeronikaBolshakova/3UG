using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public float masterVolume;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = (s.volume * masterVolume);
            s.source.loop = s.loop;
        }

    }

    void Update()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = (s.volume * masterVolume);
        }
    }

    void Start()
    {
        Play("Theme");
        SetMasterVolume(0.4f);
    }

    public void Play (string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
    }

}
