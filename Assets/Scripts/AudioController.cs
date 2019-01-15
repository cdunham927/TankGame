using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer masterMixer;
    public static AudioController music;
    public float value1 = -10;
    public float value2 = -10;

    private void Awake()
    {
        if (music == null) music = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        masterMixer = Resources.Load("MainMixer") as AudioMixer;
    }

    public void ChangeMusicVolume(float musicLvl)
    {
        //masterMixer = Resources.Load("MainMixer") as AudioMixer;
        masterMixer.SetFloat("musicVolume", musicLvl);
        value1 = musicLvl;
    }

    public void ChangeSoundVolume(float soundLvl)
    {
        //masterMixer = Resources.Load("MainMixer") as AudioMixer;
        masterMixer.SetFloat("soundVolume", soundLvl);
        value2 = soundLvl;
        //Play example sound
    }
}
