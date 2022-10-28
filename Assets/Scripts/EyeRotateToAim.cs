using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeRotateToAim : MonoBehaviour
{
    [SerializeField] Transform _aim;
    [SerializeField] Vector3 _eyeUp = new Vector3(10,0,0);
    [SerializeField] Vector3 _eyeDown = new Vector3(-45,0,0);
    void Update()
    {
        float aimY = _aim.position.y - transform.position.y;
        float invers = Mathf.InverseLerp(-7f,7f,aimY);
        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(_eyeUp),Quaternion.Euler(_eyeDown),invers);
    }
}
