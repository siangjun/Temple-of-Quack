using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //setup
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10.0f;

    //sprite setup
    public SpriteRenderer spriteRenderer;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //built-in support for arrow keys and wasd keys
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //flip sprite if necessary
        if (horizontal < 0) {
            if (facingRight) {
                Flip();
            }
        } 
        else if (horizontal > 0)
        {
            if (!facingRight) {
                Flip();
            }
        }

    }

    private void FixedUpdate()
    {
         if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        //calculate new velocity of player
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
    }

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate (0f, 180f, 0f);
    }

}
