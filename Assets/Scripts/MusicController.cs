using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    public static MusicController music;
    private void Awake()
    {
        if (music == null) music = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
