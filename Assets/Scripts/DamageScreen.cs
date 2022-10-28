using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] Volume _volume;    
    Vignette _vignette;
    void Start() {
        _volume.profile.TryGet<Vignette>(out _vignette);
    }
    public void StartEffect() {
        StartCoroutine(ShowEffect());
    }

    IEnumerator ShowEffect() {
        _vignette.active = true;
        for (float t = 0.5f; t >= 0.1f; t-= Time.deltaTime * 0.3f) {        
            _vignette.intensity.value = t; 
            yield return null;
        }
        _vignette.active = false;        
    }
}
