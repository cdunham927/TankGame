using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundMixerController : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    Slider slide;
    public AudioClip clip;
    AudioSource src;

    private void Awake()
    {
        slide = GetComponent<Slider>();
        src = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        slide.onValueChanged.AddListener(delegate { AudioController.music.ChangeSoundVolume(slide.value); });
        if (AudioController.music != null) slide.value = AudioController.music.value2;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        src.PlayOneShot(clip);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       src.PlayOneShot(clip);
    }
}
