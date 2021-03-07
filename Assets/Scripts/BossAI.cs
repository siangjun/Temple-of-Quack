using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //define variables all enemies have
    public float health = 200f;
    public float damage = 25f;
    public float speed = 8f;
    public float maxRange = 15f;
    public float minRange = 1f;

    public float attackRange = 5f;

    private bool hasDied = false;

    //setup
    Rigidbody2D body;

    private Transform target;

    //sprite setup
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (health <= 0 && hasDied)
        {
            Destroy(gameObject);

        }
        else if (health <= 0 && !hasDied)
        {
            hasDied = true;
            DecideAction();
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var collidedWith = collision.gameObject;
        if (collidedWith.GetComponent<Feather>() != null)
        {
            Feather projectile = (Feather)collidedWith.GetComponent<Feather>();
            health -= projectile.damage;
            print("hit");
        }
    }


    void DecideAction()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceFromPlayer > minRange && distanceFromPlayer < maxRange && !hasDied)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No boss rage yet, coming soon...");
        }


    }
}
