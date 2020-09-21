using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100;
    public float damage = 20;
    
    public void takeDamage()
    {
        health -= damage;
        Debug.Log(health);
    }
}
