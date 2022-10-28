using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] int _healthsValue;
    private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerHealths>() is PlayerHealths playerHealths) {
            playerHealths.AddHeaths(_healthsValue);
            Destroy(gameObject);
        }
    }
}
