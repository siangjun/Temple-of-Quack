using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;
    public float curHealth = 0;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    public void DamagePlayer( float damage )
    {
        curHealth -= damage;

        healthBar.SetHealth( curHealth );
    }

    void OnTriggerEnter2D(Collider2D collision)
        {
            print("collision");
            var collidedWith = collision.gameObject;
            if (collidedWith.GetComponent<Bullet>() != null)
            {
                Bullet projectile = (Bullet) collidedWith.GetComponent<Bullet>();
                DamagePlayer(projectile.damage);
                print("hit");
            }
        }

}