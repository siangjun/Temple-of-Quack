using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //setup
    public Transform firePoint;
    public GameObject featherPrefab;
    float lookAngle;
    public float attackSpeed;
    private float elapsedTime = 0;

    // Update is called once per frame
    void Update()
    {        

        //checks if player is attacking
        if (Input.GetButton("Fire1") && Time.time > elapsedTime)
        {
            Attack();
            elapsedTime = attackSpeed + Time.time;
        }
    }

    void Attack() 
    {
        //rotating the firePoint to follow the mouse
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lookAngle = Mathf.Atan2(mousePosition.y - firePoint.position.y, mousePosition.x - firePoint.position.x) * Mathf.Rad2Deg;


        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        Debug.Log(lookAngle);

        print("attack!");
        Instantiate(featherPrefab, firePoint.position, firePoint.rotation);

    }


}
