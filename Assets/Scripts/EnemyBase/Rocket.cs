using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] float _rotationSpeed = 3f;

    Transform _playerTransform;

    private void Start() {
        if(FindObjectOfType<PlayerMove>() != null) {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;        
        }
        
    }

    private void Update() {
        if (_playerTransform != null) {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer,Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation, Time.deltaTime * _rotationSpeed);
        }
    }

}
