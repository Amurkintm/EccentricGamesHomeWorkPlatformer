using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangForse : MonoBehaviour
{
    [SerializeField] float _radius;
    [SerializeField] float _forse;
    [SerializeField] LayerMask _layerMask;
    private void Start() {
        Explode();
    }
    public void Explode() {
        Collider[] overLappedColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);
        for (int i = 0; i < overLappedColliders.Length; i++) {
            Rigidbody rb = overLappedColliders[i].attachedRigidbody;
            if (rb) {
                rb.AddExplosionForce(_forse, transform.position, _radius);                
            }
        }
    }
}
