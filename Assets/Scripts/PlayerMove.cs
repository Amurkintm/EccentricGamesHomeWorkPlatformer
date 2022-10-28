using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _moveSpeed, _jumpForce, _friction, _maxSpeed;
    [SerializeField] Transform _transform, _startPosition;
    [SerializeField] bool _isGrounded, isSitting = false;
    [SerializeField] RaycastHit _hitInfoUp, _hitInfoDown;
    [SerializeField] PlayerHealths _playerHealths;
    
    [SerializeField] float _jumpButtonGracePeriod;
    private float? _lastGroundedTime;
    private float? _jumpButtonPressedTime;
    private bool _checkerJump = true;

    public UnityEvent ExitMapBorders;
    public UnityEvent JumpSound;
    float _moveX;
    void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update() {
        _moveX = Input.GetAxis("Horizontal");

        SetSitting();

        PositionToDie();

        if(_checkerJump == true) {
            if (_isGrounded) {                
                _lastGroundedTime = Time.time;
            }
            if (Input.GetButtonDown("Jump")) {
                _jumpButtonPressedTime = Time.time;                
            }
        }
        if (Time.time - _lastGroundedTime <= _jumpButtonGracePeriod) {

            if (Time.time - _jumpButtonPressedTime <= _jumpButtonGracePeriod) {
                Jump();
                _jumpButtonPressedTime = null;
                _lastGroundedTime = null;
                _checkerJump = false;
                Invoke(nameof(JumpControl), 0.5f);
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.C) ||
            _isGrounded == false ||
            isSitting == true) {
            _transform.localScale = Vector3.Lerp(_transform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15f);
        } else {
            _transform.localScale = Vector3.Lerp(_transform.localScale, Vector3.one, Time.deltaTime * 20f);
        }
    }
    private void FixedUpdate() {

        float speedMultiplier = 1f;
        if (!_isGrounded) {
            speedMultiplier = 0.2f;
            if (_rb.velocity.x > _maxSpeed && _moveX > 0) {
                speedMultiplier = 0;
            }
            if (_rb.velocity.x < -_maxSpeed && _moveX < 0) {
                speedMultiplier = 0;
            }
        }
        _rb.AddForce(_moveX * _moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (_isGrounded) {
            _rb.AddForce(-_rb.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }
    }
    private void Jump() {        
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        JumpSound?.Invoke();        
    }
    private void OnCollisionStay(Collision col) {

        float angle = Vector3.Angle(col.contacts[0].normal, Vector3.up);
        if (angle < 45f) {
            _isGrounded = true;
        }

    }
    private void OnCollisionExit(Collision col) {
        _isGrounded = false;
    }
    private void PositionToDie() {
        if (transform.position.y < -5f) {
            transform.position = _startPosition.position;
            ExitMapBorders?.Invoke();
            _rb.velocity = Vector3.zero;
            _playerHealths.TakeDamage(1);
        }
    }
    private void SetSitting() {
        bool hitUp = Physics.SphereCast(transform.position, 0.5f, Vector3.up, out _hitInfoUp);
        Physics.SphereCast(transform.position, 0.5f, Vector3.down, out _hitInfoDown);
        float direction = _hitInfoUp.distance + _hitInfoDown.distance;
        if (direction > 0.5f || hitUp == false) {
            isSitting = false;
        } else isSitting = true;

    }    
    void JumpControl() {
        _checkerJump = true;
    }
}