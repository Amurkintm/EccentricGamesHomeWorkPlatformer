using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGreator : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Transform _spawn;

    public void Greate() {
        Instantiate(_prefab, _spawn.position, _spawn.rotation); 
    }
}
