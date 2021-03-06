using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //built-in support for arrow keys and wasd keys
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //checks if player is attacking
        if(Input.GetKeyDown("space")) 
        {
            Attack();
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

    void Attack() 
    {
        print("attack!");
    }

}
