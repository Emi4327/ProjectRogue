using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public void Attack()
    {
        weapon.Attack();
    }
}
