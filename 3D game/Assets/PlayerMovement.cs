using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Movement")]
    public CharacterController controller;
    private float walkSpeed = 10f;
    private float runSpeed = 20f;
    public float moveSpeed;

    [Header("Gravity")]
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.3f;

    public LayerMask groundMask;
    private bool grounded;

    [Header("Jump")]
    public float jumpHeight = 2f;

    [Header("Running")]
    public bool running;

    void Start() {

    }
    void Update() {
        jump();
        applyGravity();
        movePlayer();
    }
    void jump(){
        if (Input.GetButtonDown("Jump") && grounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void movePlayer(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
      
        if(Input.GetKey(KeyCode.LeftShift) && grounded){
            moveSpeed = runSpeed;
            running = true;
        } else if (grounded) {
            moveSpeed = walkSpeed;
            running = false;
        } 
    }

    void applyGravity() {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(grounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
