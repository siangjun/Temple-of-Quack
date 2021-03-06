using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }
}