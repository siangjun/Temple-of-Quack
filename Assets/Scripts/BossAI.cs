using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    //define variables all enemies have
    public float health = 100f;
    public float damage = 20f;
    public float speed = 8f;
    public float maxRange = 15f;
    public float minRange = 1f;

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
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        DecideAction();
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
        if (distanceFromPlayer > minRange && distanceFromPlayer < maxRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (distanceFromPlayer > maxRange)
        {
            body.velocity = new Vector2(0, 0);
        }

    }
}
