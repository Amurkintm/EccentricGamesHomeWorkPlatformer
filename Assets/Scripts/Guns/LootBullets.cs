using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] int _gunIndex;
    [SerializeField] int _numberOfBullets;
    private void OnTriggerEnter(Collider other) {
        if (other.attachedRigidbody && other.attachedRigidbody.GetComponent<PlayerArmory>() is PlayerArmory playerArmory) {
            playerArmory.AddBullets(_gunIndex, _numberOfBullets);
            Destroy(gameObject);
        }
    }
}
