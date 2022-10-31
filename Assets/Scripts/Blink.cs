using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] Renderer[] _renderes;
   
    public void StartBlink() {
        StartCoroutine(BlinkEffect());
    }
    private void OnEnable() {
        SetColor(Color.clear);
    }
    public IEnumerator BlinkEffect() {        
            for (float t = 0; t < 1; t += Time.deltaTime * 0.8f) {
                SetColor(new Color(Mathf.Sin(t * 25f) * 0.5f + 0.5f, 0, 0, 0));
                yield return null;
            }
            SetColor(Color.clear);
    }
    public void SetColor(Color color) {
        for (int i = 0; i < _renderes.Length; i++) {
            for (int m = 0; m < _renderes[i].materials.Length; m++) {
                _renderes[i].materials[m].SetColor("_EmissionColor", color);
            }
        }
    }    
}
