using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIHelper : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Transform Target {  get { return target; } }

    private void Start()
    {
        if(target == null)
        {
            target = GameManager.Instance.Player.transform;
        }
    }
}
