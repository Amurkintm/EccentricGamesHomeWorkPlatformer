using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] float Period = 5f;
    [SerializeField] Animator _animator;
    private float _timer;

    [SerializeField] string _triggerName = "Attack";

    private void Update() {
        _timer += Time.deltaTime;
        if(_timer > Period) {
            _timer = 0;
            _animator.SetTrigger(_triggerName);
        }
    }
}
