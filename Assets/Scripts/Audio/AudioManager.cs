using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioFile[] audioFiles;

    public AudioSource MusicSource;
    public AudioSource SFXSource;

    public float GeneralMusicVolume;
    public float GeneralSFXVolume;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

    public static void PlayMusic(string fileName)
    {
        Instance._PlayMusic(fileName);
    }

    private void _PlayMusic(string name)
    {
        AudioFile file = GetFileByName(name);

        if (file != null)
        {
            float vol = GeneralMusicVolume * file.volume;
            MusicSource.volume = vol;
            MusicSource.clip = file.clip;
            MusicSource.Play();
        }
        else
        {
            Debug.Log("Wrong input for Audio: " + name);
        }
    }

    public static void PlaySFX(string fileName)
    {
        Instance._PlaySFX(fileName);
    }

    public static void PlaySFX(string fileName, AudioSource source)
    {
        Instance._PlaySFX(fileName, source);
    }

    private void _PlaySFX(string name)
    {
        AudioFile file = GetFileByName(name);

        if (file != null)
        {
            float vol = GeneralSFXVolume * file.volume;
            SFXSource.volume = vol;
            SFXSource.clip = file.clip;
            SFXSource.Play();
        }
        else
        {
            Debug.Log("Wrong input for Audio: " + name);
        }
    }

    private void _PlaySFX(string name, AudioSource source)
    {
        AudioFile file = GetFileByName(name);

        if (file != null)
        {
            float vol = GeneralSFXVolume * file.volume;
            source.volume = vol;
            source.clip = file.clip;
            source.Play();
        }
        else
        {
            Debug.Log("Wrong input for Audio: " + name);
        }
    }

    private AudioFile GetFileByName(string name)
    {
        return audioFiles.First(x => x.name == name);    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
