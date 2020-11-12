﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public void UpdateHealthBar(Health health)
    {
        healthBar.fillAmount = health.GetNormalizedHealth();
    }
}
