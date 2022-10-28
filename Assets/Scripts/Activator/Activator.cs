using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();
    [SerializeField] Transform _playerTransform;

    private void Update() {
        if (_playerTransform == null) return;
        for (int i = 0; i < ObjectsToActivate.Count; i++) {
            ObjectsToActivate[i].CheckDistance(_playerTransform.position);            
        }
    }
}
