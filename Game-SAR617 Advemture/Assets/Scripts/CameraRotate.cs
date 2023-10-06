using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 13f;
    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    
    void FixedUpdate()
    {
        float cameraAngle = _camera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, cameraAngle, 0f), rotateSpeed * Time.fixedDeltaTime);
    }
}
