using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField] Bullet _bullet;
    [SerializeField] int _damageValue;
    [SerializeField] float _mass;
    private void Update() {
        if (Input.GetKey(KeyCode.Mouse0) && BulletIsReady) {
            _bullet.Damage = _damageValue;
            Shot();
        }
    }
    public override void Activate() {
        base.Activate();        
        _bullet.GetMass(_mass);
        _bullet.Damage = _damageValue;
    }
}
