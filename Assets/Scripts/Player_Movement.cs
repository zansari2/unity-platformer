using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player movement
public class Player_Movement : MonoBehaviour
{
    // Public Variables
    public float speed;             // Movement speed
    public Vector2 jumpHeight;        // Jump height
    public Rigidbody2D rb;          // Hold character physics

    // Private Variables
    private bool isRight = true;    // Check player facing direction
    private bool isOnGround = true; // Check if player is grounded
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input and create a movement vector
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(h*speed, rb.velocity.y);

        // Change character velocity
        rb.velocity = movement;

        // Flip the sprite based on horizontal input
        if (h < 0 && isRight == true)
        {
            Flip();
        }
        else if (h > 0 && isRight == false)
        {
            Flip();
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.AddForce(jumpHeight, ForceMode2D.Impulse);
            isOnGround = false;
        }
        
    }

    // Flip the sprite
    void Flip()
    {
        // Reverse the boolean
        isRight = !isRight;

        // Scale sprite backwards
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Check for collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Set grounded state 
        isOnGround = true;
        // Check if death
        if (collision.gameObject.tag == "Kill_Player") {
            Destroy(gameObject);
        }
    }
}
