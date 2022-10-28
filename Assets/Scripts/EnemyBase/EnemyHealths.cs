using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealths : MonoBehaviour
{
    [SerializeField] int _health = 1;
    public UnityEvent EventOnTakeDamage;

    public void TakeDamage(int damageValue) {
        _health-=damageValue;
        if(_health <= 0) {            
            Die();
        }
        EventOnTakeDamage!.Invoke();
    }
    public void Die() {        
        Destroy(gameObject);
    }
}
