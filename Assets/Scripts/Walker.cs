using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    left, 
    right
}
public class Walker : MonoBehaviour
{
    [SerializeField] Transform _leftTarget;
    [SerializeField] Transform _rightTarget;
    [SerializeField] Transform _rayStart;

    [SerializeField] float _speed;    

    [SerializeField] float _stopTime;

    public Direction CurrentDirection;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private bool _isStopped;

    private void Start() {
        _leftTarget.parent = null;
        _rightTarget.parent = null;
    }

    void Update() {
        if(_isStopped == true) {
            return;
        }
        if (CurrentDirection == Direction.left) {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x < _leftTarget.position.x) {
                CurrentDirection = Direction.right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                EventOnLeftTarget.Invoke();
            }
        } else { 
            transform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x > _rightTarget.position.x) { 
                CurrentDirection=Direction.left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                EventOnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if(Physics.Raycast(_rayStart.position,Vector3.down,out hit)) {
            transform.position = hit.point;
        }
    } 
    void ContinueWalk() {
        _isStopped = false;
    }
}
