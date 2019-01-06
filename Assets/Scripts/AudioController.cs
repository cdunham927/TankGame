using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer masterMixer;

    public void ChangeMusicVolume(float musicLvl)
    {
        masterMixer.SetFloat("musicVolume", musicLvl);
    }

    public void ChangeSoundVolume(float soundLvl)
    {
        masterMixer.SetFloat("soundVolume", soundLvl);
    }
}
