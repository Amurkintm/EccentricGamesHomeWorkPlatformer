using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mishen : MonoBehaviour
{
    
    [SerializeField] GameObject _effectPref;
    [SerializeField] GameObject _henPref;
    bool _check = true;
    Vector3 angle = new Vector3(0,0,0);
    TargetManager _targetManager;
    public Transform point;    
    public void Setup(TargetManager targetManager) {
        _targetManager = targetManager;
    }
    
    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.GetComponent<Bullet>() && _check) {
            _check = false;
            Instantiate(_effectPref,point.position, Quaternion.Euler(angle));
            Instantiate(_henPref, point.position, point.rotation);
            Destroy(gameObject);
            _targetManager.RemoveOne();
        }
    }    
}