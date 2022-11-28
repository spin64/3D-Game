using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerBody;
    public float senstivity = 100f;
    float xRotation = 0f;
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        Look();
    }

    void Look() {
        float mouseX = Input.GetAxisRaw("Mouse X") * senstivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * senstivity * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
