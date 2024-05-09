using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private WeaponsEnum weaponEnum;
    [SerializeField] protected WeaponSO weaponSO;
    [SerializeField] private RangedWeapon rangedWeapon;
    private float timer;
    protected bool canAttack = true;
    protected InputManager inputManager;
    protected EnemyAIHelper enemyAIHelper;

    private void Start()
    {
        enemyAIHelper = transform.GetComponentInParent<EnemyAIHelper>();
        inputManager = transform.GetComponentInParent<InputManager>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>= 1/weaponSO.AttackSpeed)
        {
            timer = 0;
            canAttack = true;
        }
    }
    public void Attack()
    {
        if(!canAttack) return;
        rangedWeapon.Fire();
        canAttack = false;
    }
}
