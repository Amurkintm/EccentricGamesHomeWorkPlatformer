using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Carrot : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _speed;
    private void Start() {
        if (FindObjectOfType<PlayerHealths>() != null){
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        _rb = GetComponent<Rigidbody>();
        Transform playerTransform = FindObjectOfType<PlayerHealths>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        _rb.velocity = toPlayer * _speed;
        Destroy(gameObject, 15f);
        }
    }
}
