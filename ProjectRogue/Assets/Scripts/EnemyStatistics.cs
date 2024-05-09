using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatistics : Statistics
{
    [SerializeField] private Slider enemyHPBar;
    
    protected override void Start()
    {
        enemyHPBar.maxValue = maxHealth;
        enemyHPBar.value = health;
    }
    public override void TakeDamage(float damage)
    {
        health -= damage;
        enemyHPBar.value = health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
