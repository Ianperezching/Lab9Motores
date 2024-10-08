using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2D : MonoBehaviour
{

    private Rigidbody2D myRBD2;
    [SerializeField] private float velocity = 5f; 
    
    private void Awake()
    {
        myRBD2 = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
        Vector2 movementInput = context.ReadValue<Vector2>(); 
        Vector2 movement = new Vector2(movementInput.x * velocity, movementInput.y * velocity);
        myRBD2.velocity = movement;
    }
}
