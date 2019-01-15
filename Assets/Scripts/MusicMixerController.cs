using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicMixerController : MonoBehaviour {
    Slider slide;

    private void Awake()
    {
        slide = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        slide.onValueChanged.AddListener(delegate { AudioController.music.ChangeMusicVolume(slide.value); });
        if (AudioController.music != null) slide.value = AudioController.music.value1;
    }
}
