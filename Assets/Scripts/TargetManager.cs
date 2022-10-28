using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] Mishen[] _mishenes;
    int _numberOfMishenes;
    [SerializeField] TMP_Text _text;
    [SerializeField] TMP_Text _textResult;
    [SerializeField] PlayerHealths _playerHealths;
    private void Start() {
        _mishenes = GetComponentsInChildren<Mishen>();
        _numberOfMishenes = _mishenes.Length;
        for (int i = 0; i < _mishenes.Length; i++) {
            _mishenes[i].Setup(this);
        }
        _text.text = "ќсталось €иц: " + _numberOfMishenes.ToString();
    }
    public void RemoveOne() {
        _numberOfMishenes--;
        _text.text = "ќсталось €иц: " + _numberOfMishenes.ToString();
        if (_numberOfMishenes <= 0) {
            _textResult.enabled = true;
            _textResult.text = "ѕобеда!";
        }        
    }
    public void GameOver() {
        _textResult.enabled = true;
        _textResult.text = "»гра окончена!";
    }
    public void StartGame() {
        _textResult.enabled = false;
    }
}
