using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }

}
