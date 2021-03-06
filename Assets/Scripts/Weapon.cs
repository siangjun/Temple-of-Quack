﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //setup
    public Transform firePoint;
    public GameObject featherPrefab;
    Vector2 mousePosition;
    float lookAngle;

    // Update is called once per frame
    void Update()
    {
        //rotating the firePoint to follow the mouse
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;


        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

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