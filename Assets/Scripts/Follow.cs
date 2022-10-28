using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Transform _cameraCentre;
    [SerializeField] float _lerpRate;
    [SerializeField] float _speed = 10f;
    Vector3 _offset = Vector3.zero;


    void Update() {
        if (_target != null) {
            Vector3 target = _target.position;
            float mouseX = 0.5f + (Input.mousePosition.x - (Screen.width / 2)) / Screen.width * 8f;
            float mouseY = 0.5f + (Input.mousePosition.y - (Screen.width / 2)) / Screen.width * 10f;
            _offset = new Vector3(mouseX, mouseY, _offset.z);
            target += _offset;
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * _lerpRate);
            if (Input.GetKey(KeyCode.Tab)) {
                _offset = Vector3.MoveTowards(_offset, new Vector3(0, 1.5f, -7f), _speed * Time.deltaTime);
            } else {
                _offset = Vector3.MoveTowards(_offset, Vector3.zero, _speed * Time.deltaTime);
            }
        }
    }
}