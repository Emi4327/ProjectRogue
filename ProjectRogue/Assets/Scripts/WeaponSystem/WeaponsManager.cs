using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] private RangedWeapon weapon;

    public void Attack()
    {
        weapon.Fire();
    }
}
