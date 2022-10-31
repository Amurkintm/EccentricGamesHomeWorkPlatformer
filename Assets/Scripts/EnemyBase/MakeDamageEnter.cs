using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageEnter : MonoBehaviour
{
    [SerializeField] int _damageValue = 1;
    private void OnCollisionEnter(Collision collision) {
        Touch(collision.collider);        
    }
    private void OnTriggerEnter(Collider other) {
        Touch(other);        
    }
     
    private void Touch(Collider collider) {
        if (collider.attachedRigidbody && collider.attachedRigidbody.GetComponent<PlayerHealths>() is PlayerHealths playerHealths) {            
            playerHealths.TakeDamage(_damageValue);            
        }
    }    
}
