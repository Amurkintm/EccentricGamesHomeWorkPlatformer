using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStayPlatform : MonoBehaviour
{
    private void OnCollisionStay(Collision col) {        
            float angle = Vector3.Angle(col.contacts[0].normal, Vector3.up);
            if (angle > 95f && col.gameObject.GetComponent<PlayerHealths>() is PlayerHealths playerHealths) {
                playerHealths.transform.parent = transform;            
        }
    }
    private void OnCollisionExit(Collision col) {
        if (col.gameObject.GetComponent<PlayerHealths>() is PlayerHealths playerHealths) {
            playerHealths.transform.parent = null;
        }
    }
}
