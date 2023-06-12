using MoreMountains.NiceVibrations;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region singleton
    public static AudioManager Instance;
    void Awake()
    {
        Instance = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = 1;
            s.source.loop = s.loop;
        }
    }
    #endregion
    public Sound[] sounds;

    private void Start()
    {
        this.RegisterListener(EventID.OnGameEndlessOver, (x) => Vibrate());
        PlayBackgroundMusic();
    }
    public void PlayBackgroundMusic()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "BackgroundMusic");
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (PlayerPrefs.GetInt("MusicOn", 1) == 1)
        {
            s.source.Play();
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        if (PlayerPrefs.GetInt("SoundOn", 1) == 1)
        {
            s.source.Play();
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
    public void Vibrate()
    {
        MMVibrationManager.Vibrate();
    }
    public void ButtonClick()
    {
        Play("ButtonClick");
    }
}