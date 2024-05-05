using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Weapons", order = 1)]
public class WeaponSO : ScriptableObject
{
    [Tooltip("Attacks per second")]
    public float AttackSpeed = 1f;
    [Tooltip("Damage per attack")]
    public float Damage = 10f;
    public int amountOfProjectiles;
    public float projectileSpeed;
}
