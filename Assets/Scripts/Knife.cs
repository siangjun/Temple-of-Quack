using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private Transform target;
    public float damage = 10f;
    public float maxRange = 3f;
    public int cooldown = 20;
    public bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceFromPlayer > maxRange)
        {
            canAttack = false;
        }

        if (canAttack)
        {
            PlayerController player = (PlayerController) target.GetComponent<PlayerController>();
            player.DamagePlayer(damage);
            canAttack = false;
        }
        else {
            cooldown -= 1;
            if (cooldown <= 0)
            {
                canAttack = true;
                cooldown = 20;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
        canAttack = true;
    }

}
