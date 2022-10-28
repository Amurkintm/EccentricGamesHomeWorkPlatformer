using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] Vector3 _leftEuler;
    [SerializeField] Vector3 _rightEuler = new Vector3(0, -180f, 0);
    Vector3 _targetEuler;
    [SerializeField] float _rotationSpeed = 5f;
    Transform _playerTransform;
    private void Start() {

        _playerTransform = FindObjectOfType<PlayerHealths>().transform;

    }
    private void Update() {
        if (_playerTransform == null) return;

        if (transform.position.x < _playerTransform.position.x) {
            _targetEuler = _rightEuler;
        } else {
            _targetEuler = _leftEuler;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * _rotationSpeed);
    }
}
