using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Setting : MonoBehaviour
{
    [SerializeField] Sprite soundOn, soundOff;
    [SerializeField] Sprite musicOn, musicOff;
    [SerializeField] Image music, sound;

    // Start is called before the first frame update
    private void Awake()
    {
        UpdateAudioStatus();
    }

    // Update is called once per frame
    void UpdateAudioStatus()
    {
        if (PlayerPrefs.GetInt("SoundOn",1) == 1)
            sound.sprite = soundOn;
        else
            sound.sprite = soundOff;

        if (PlayerPrefs.GetInt("MusicOn",1) == 1)
        {
            music.sprite = musicOn;
        }
        else
            music.sprite = musicOff;
    }
    public void ToggleSound()
    {
        PlayerPrefs.SetInt("SoundOn", 1 - PlayerPrefs.GetInt("SoundOn",1));
        UpdateAudioStatus();
    }
    public void ToggleMusic()
    {
        PlayerPrefs.SetInt("MusicOn", 1 - PlayerPrefs.GetInt("MusicOn",1));
        if (PlayerPrefs.GetInt("MusicOn", 1) == 1)
            AudioManager.Instance.PlayBackgroundMusic();
        else
            AudioManager.Instance.Stop("BackgroundMusic");
        UpdateAudioStatus();
    }

}
