using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //setup
    public Transform firePoint;
    public GameObject featherPrefab;

    // Update is called once per frame
    void Update()
    {
        //checks if player is attacking
        if(Input.GetButton("Fire1")) 
        {
            Attack();
        }
    }

    void Attack() 
    {
        print("attack!");
        Instantiate(featherPrefab, firePoint.position, firePoint.rotation);

    }
}
