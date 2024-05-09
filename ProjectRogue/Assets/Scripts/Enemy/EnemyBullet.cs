using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    Vector3 direction;
    private float damage;
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        int layerMask = ~(LayerMask.GetMask("Enemy"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, speed * Time.deltaTime, layerMask);
        if(hit.collider != null)
        {
            HandleCollision(hit);
        }
    }
    public void Initialize(WeaponSO weaponSO, Transform target)
    {
        speed = weaponSO.projectileSpeed;
        direction = (target.position - transform.position).normalized;
        damage = weaponSO.Damage;
    }
    private void HandleCollision(RaycastHit2D hit)
    {
        var targetStats = hit.collider.GetComponent<Statistics>();
        if(targetStats)
        {
            targetStats.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
