using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int _damage = 1;
    public int Damage {
        get { return _damage; }
        set { _damage = value; }
    }
    
    [SerializeField] GameObject _hitDecalPref;
    [SerializeField] Rigidbody _rb;
    [SerializeField] int _hitCount;
    Vector3 _lastVelocity;
    private void Start() {
        DestroyBullet(3f);        
    }
    private void Update() {        
        _lastVelocity = _rb.velocity;
    }
    private void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.GetComponent<EnemyHealths>() || coll.gameObject.GetComponent<Mishen>()) {
            BulletHit();
        }
        if (coll.gameObject.GetComponent<Platform>()) {
            if (_hitCount < Random.Range(1,4)) {
                var _speed = _lastVelocity.magnitude;
                var direction = Vector3.Reflect(_lastVelocity.normalized, coll.contacts[0].normal);
                _rb.velocity = direction * Mathf.Max(_speed, 0f);
            } else {
                DestroyBullet(0f);
            }
        }
        _hitCount++;
    }
    public void DestroyBullet(float value) {
        Destroy(gameObject, value);
        _hitCount = 0;
    }
    public void BulletHit() {
        GameObject newHitDecal = Instantiate(_hitDecalPref, transform.position, Quaternion.identity);
        Destroy(newHitDecal.gameObject, 0.7f);
        DestroyBullet(0f);
    }
    public void GetMass(float mass) {
        _rb.mass = mass;
    }
}
