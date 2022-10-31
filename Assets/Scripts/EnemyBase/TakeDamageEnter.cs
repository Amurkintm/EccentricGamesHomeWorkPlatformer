using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageEnter : MonoBehaviour
{    
    [SerializeField] EnemyHealths _enemyHealths;
    [SerializeField] bool _destroyOnAnyCollosion;
    private void OnCollisionEnter(Collision collision) {
        Touch(collision.collider);
        if (_destroyOnAnyCollosion == true) {
            _enemyHealths.Die();
        }
    }
    private void OnTriggerEnter(Collider other) {        
            Touch(other);
    }
    void Touch(Collider collider) {
        if (collider.attachedRigidbody && collider.attachedRigidbody.GetComponent<Bullet>() is Bullet bullet) {
            bullet.BulletHit();
            _enemyHealths.TakeDamage(bullet.Damage);
        }
        else if (_destroyOnAnyCollosion == true && collider.isTrigger == false) {
            _enemyHealths.Die();
        }
    }
}