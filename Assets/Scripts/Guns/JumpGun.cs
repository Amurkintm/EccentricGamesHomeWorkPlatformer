using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed;
    [SerializeField] Transform _spawn;
    [SerializeField] Gun _gun;
    [SerializeField] float _maxCharge = 3f;
    [SerializeField] ChargeIcon _chargeIcon;
    float _currentCharge;
    bool _isCharged;

    private void Update() {

        if (_isCharged) {
            if (_gun.isActiveAndEnabled == true && _gun.BulletIsReady == true && Input.GetKeyDown(KeyCode.LeftShift)) {
                _rb.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                _gun.Shot();
                _isCharged = false;
                _currentCharge = 0f;
                _chargeIcon.StarCharge();
                
            }
        } else {
            _currentCharge += Time.unscaledDeltaTime;            
            _chargeIcon.SetChargeValue(_currentCharge,_maxCharge);
            if (_currentCharge > _maxCharge) {
                _isCharged = true;
                _chargeIcon.StopCharge();
            }
        }
    }
}
