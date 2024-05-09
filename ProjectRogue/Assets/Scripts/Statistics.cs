using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Statistics : MonoBehaviour
{
    [SerializeField] protected float speed = 5;
    public float Speed {  get { return speed; } }
    [SerializeField] protected float health = 100;
    [SerializeField] protected float maxHealth = 100;

    protected virtual void Start()
    {
        GameManager.Instance.UIManager.SetMaxHealth(maxHealth);
        GameManager.Instance.UIManager.SetHealth(health);
    }
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        GameManager.Instance.UIManager.SetHealth(health);
        if(health <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
