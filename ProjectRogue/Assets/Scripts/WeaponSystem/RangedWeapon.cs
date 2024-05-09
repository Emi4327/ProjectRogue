using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;


    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        if(bullet.GetComponent<Bullet>())
        {
            bullet.GetComponent<Bullet>().Initialize(weaponSO, inputManager);
        }
        else
        {
            bullet.GetComponent<EnemyBullet>().Initialize(weaponSO, enemyAIHelper.Target);
        }
    }
}
