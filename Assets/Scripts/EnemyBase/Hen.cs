using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    Rigidbody _rb;
    Transform _playerTransform;
    [SerializeField] float _speed;
    [SerializeField] float _timeToReachSpeed;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerHealths>().transform;        
    }
    private void FixedUpdate() {
        if (_playerTransform == null) return;
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rb.mass * (toPlayer * _speed - _rb.velocity) / _timeToReachSpeed;
        _rb.AddForce(force);
    }
}
