using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    public void SetHealth(float health)
    {
        healthBar.SetHealth(health);
    }
    public void SetMaxHealth(float maxHealth)
    {
        healthBar.SetMaxHealth(maxHealth);
    }
}
