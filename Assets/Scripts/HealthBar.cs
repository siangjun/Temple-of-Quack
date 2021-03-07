using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public float playerHealth;
    public PlayerController player;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = player.maxHealth;
        healthBar.value = player.maxHealth;
    }

    

    public void SetHealth(float hp)
    {
        healthBar.value = hp;
    }
}