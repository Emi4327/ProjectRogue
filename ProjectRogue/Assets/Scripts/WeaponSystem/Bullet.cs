using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private float damage;
    Vector3 direction;
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        int layerMask = ~(LayerMask.GetMask("Player"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, speed * Time.deltaTime, layerMask);
        if(hit.collider != null)
        {
            HandleCollision(hit);
        }
    }
    public void Initialize(WeaponSO weaponSO, InputManager inputManager)
    {
        speed = weaponSO.projectileSpeed;
        damage = weaponSO.Damage;
        SetDirectionTowardsMouse(inputManager);
    }
    private void SetDirectionTowardsMouse(InputManager inputManager)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(inputManager.GetMousePosition());
        mousePosition.z = 0f;
        direction = (mousePosition - transform.position).normalized;
    }

    private void HandleCollision(RaycastHit2D hit)
    {
        hit.collider.GetComponent<EnemyStatistics>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
