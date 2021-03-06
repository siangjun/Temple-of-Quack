using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public HealthBar healthBar;

    
    public void DamagePlayer( int damage )
    {
        curHealth -= damage;

        healthBar.SetHealth( curHealth );
    }
}
