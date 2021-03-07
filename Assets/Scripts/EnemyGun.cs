using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    //setup
    public Transform firePoint;
    public GameObject bulletPrefab;
    float lookAngle;
    private Transform target;

    //Start
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //attack every few seconds
        InvokeRepeating("Attack", 2.0f, 1f);
    }
    
    // Update is called once per frame
    void Update()
    {
        var playerPosition = target.position;
        lookAngle = Mathf.Atan2(playerPosition.y - firePoint.position.y, playerPosition.x - firePoint.position.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

    }

    void Attack() 
    {
        print("attack!");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

}
