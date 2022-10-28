using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] float DistanceToActivate = 15f;
    bool _isActive = true;
    Activator _activator;
    private void Start() {
        _activator = FindObjectOfType<Activator>();
        _activator.ObjectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition) {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (_isActive) {
            if (distance > DistanceToActivate + 2f) {
                Deactivate();
            }
        } else {
            if (distance < DistanceToActivate) {
                Activate();                
            }
        }
    }
    public void Activate() {
        _isActive = true;
        gameObject.SetActive(true);                
    }
    public void Deactivate() {
        _isActive = false;
        gameObject.SetActive(false);
    }
    private void OnDestroy() {
        _activator.ObjectsToActivate.Remove(this);
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif
}
