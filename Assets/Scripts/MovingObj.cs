using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{  
    [SerializeField] List<GameObject> _points = new List<GameObject>();
    [SerializeField] GameObject _obj;
    [SerializeField] float _speed;

    Transform _targetPoint;
    int _countPoint;
    void Start() {
        _countPoint = 0;
        _targetPoint = _points[_countPoint].transform;
    }
    void Update() {
        if (_obj) {
            if (_obj.transform.position == _targetPoint.position) {
                _countPoint++;
                if (_countPoint >= _points.Count) {
                    _countPoint = 0;
                }
                _targetPoint = _points[_countPoint].transform;
            }
            _obj.transform.position = Vector3.MoveTowards(_obj.transform.position, _targetPoint.position, _speed * Time.deltaTime);
        }
    }
}