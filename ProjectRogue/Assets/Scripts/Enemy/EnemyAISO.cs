using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyAI", menuName = "EnemyAI", order = 1)]
public class EnemyAISO : ScriptableObject
{
    public float Speed = 50;
    public float NextWaypointDistance = 3;
    public float RepathRate = 0.5f;
    public float StopDistance = 3f;
    public float AttackDistance = 3.2f;
    [Tooltip("Attacks per second")]
    public float AttackSpeed = 1f;
}
