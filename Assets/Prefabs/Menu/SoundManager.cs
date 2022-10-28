using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _music;
    public void SetMusicEnable(bool value) {
        _music.enabled = value;
    }
    public void SetVolume(float value) {
        AudioListener.volume = value;
    }
}
