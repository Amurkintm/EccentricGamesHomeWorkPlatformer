using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform _aim;
    [SerializeField] Camera _camera;
    [SerializeField] Transform _body;

    [SerializeField] float _rotationSpeed;
    private void Start() {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }
    void LateUpdate() {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        _aim.position = point;
        Vector3 toAim = _aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        float rotY = Mathf.Clamp(_aim.localPosition.x * -30f, -30f, 30f);
        Quaternion rot = Quaternion.Euler(0, rotY, 0);        
        _body.localRotation = Quaternion.Lerp(_body.localRotation, rot, _rotationSpeed * Time.deltaTime);        
    }
}