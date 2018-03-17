using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource music;
    public AudioSource sfx;
    void Awake() {
        music.volume = PlayerPrefs.GetFloat("music volume");
        sfx.volume = PlayerPrefs.GetFloat("music volume");

    }


}
