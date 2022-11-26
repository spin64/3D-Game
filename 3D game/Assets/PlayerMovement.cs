using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Looking")]
    private float axisY = 0f, axisX = 0f;

     [Header("Movement")]
    private Rigidbody rb;
    private Transform orientation;
    public float walkspeed = 5f, senstivity = 2f;
    bool running = false;
    

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
        orientation = gameObject.GetComponent<Transform>();
    }

    void Update() {
        Look();
    }

    void FixedUpdate() {
        Movement();
    }

    void Look() {
        axisY -= Input.GetAxisRaw("Mouse Y") * senstivity;
        axisY = Mathf.Clamp(axisY, -90f, 90f);

        axisX += Input.GetAxisRaw("Mouse X") * senstivity;

        Camera.main.transform.localRotation = Quaternion.Euler(axisY, axisX, 0);
    }

    void Movement() {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * zDirection + orientation.right * xDirection;

        transform.position += moveDirection.normalized * walkspeed;
    }
}
