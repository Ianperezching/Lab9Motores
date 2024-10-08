using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;
    [SerializeField] private float moveSpeed = 6f;  
    [SerializeField] private float jumpStrength = 8f; 
    [SerializeField] private LayerMask groundLayer; 
    private Vector3 direction;  

    private bool isGrounded = false;
    private bool jumpRequest = false;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }

    
    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>(); 
        direction = new Vector3(input.x, 0, input.y);  
    }

    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            jumpRequest = true; 
        }
    }

    private void Update()
    {
       
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        if (jumpRequest && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    
    private void Move()
    {
        Vector3 move = direction * moveSpeed * Time.fixedDeltaTime;  
        myRB.MovePosition(transform.position + move);  
    }

    
    private void Jump()
    {
        myRB.AddForce(Vector3.up * jumpStrength, ForceMode.VelocityChange);  
        jumpRequest = false;  
    }
}

