using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    public int damage = 1;
    public TMP_Text healthText;
    private bool isDead = false;

    private void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }
    public void takeDamage()
    {
        health -= damage;
        Debug.Log(health);
        healthText.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            isDead = true;
        }

        if(isDead == true)
        {
            health = 0;
            healthText.text = "Health: " + health.ToString();
        }
    }
}
