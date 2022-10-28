using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueFix : MonoBehaviour
{
    [SerializeField] GameObject _gameObj;    
    void Update()
    {
        if (_gameObj != null) {
        _gameObj.transform.position = transform.position;
        }
    }
}
