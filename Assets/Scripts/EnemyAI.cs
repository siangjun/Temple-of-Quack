using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //define variables all enemies have
    public float health = 100f;
    public float damage = 20f;
    public float speed = 8f;
    public float maxRange = 15f;
    public float minRange = 1f;

    public float attackRange = 5f;

    //setup
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    private Transform target;

    //sprite setup
    public SpriteRenderer spriteRenderer;
    bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() 
    {
        DecideAction();
    }


    void DecideAction()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, target.position);
        if(distanceFromPlayer > minRange && distanceFromPlayer < maxRange) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    
    }
}
