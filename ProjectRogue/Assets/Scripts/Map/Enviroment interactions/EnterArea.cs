using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterArea : MonoBehaviour
{
    private BoxCollider2D myCollider;
    [SerializeField] private List<EnemyStateMachine> enemiesInArea = new List<EnemyStateMachine>();
    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform player = collision.transform;
        if(player.transform.position.y >= transform.position.y)
        {
            ActivateArea();
        }

    }

    private void ActivateArea()
    {
        myCollider.isTrigger = false;

    }
}
