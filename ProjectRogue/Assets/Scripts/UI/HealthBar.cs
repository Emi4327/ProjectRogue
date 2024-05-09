using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text amount;
    [SerializeField] private Slider fill;
    public void SetHealth(float health)
    {
        amount.text = health.ToString() + "/" + fill.maxValue.ToString();
        fill.value = health;
    }
    public void SetMaxHealth(float maxHealth)
    {
        amount.text = fill.value.ToString() + "/" + maxHealth.ToString();
        fill.maxValue = maxHealth;
    }
}
