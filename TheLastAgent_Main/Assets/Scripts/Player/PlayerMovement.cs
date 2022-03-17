using UnityEngine;

using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    
    private float movementSpeed = 6.5f;

    private Vector2 movementInput;
    private Rigidbody2D rb2d;
        
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    private void OnMove(InputValue input)
    {
        // gets the player input 
        movementInput = input.Get<Vector2>();
    }

    
    
    private void FixedUpdate()
    {
        // moves the player depending on movespeed an player input
        rb2d.velocity = movementInput * movementSpeed;
    }
}
