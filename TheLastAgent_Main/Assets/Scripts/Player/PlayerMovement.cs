using UnityEngine;

using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] private float movementSpeed = 6;

    private Vector2 movementInput;
    private Rigidbody2D rb2d;
        
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    private void OnMove(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }

    
    
    private void FixedUpdate()
    {
        rb2d.velocity = movementInput * movementSpeed;
    }
}
