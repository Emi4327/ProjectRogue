using Pathfinding;
using StateMachineNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBehaviour : StateBehaviour
{
    private EnemyStateMachine machine;
    private Transform target; // Player's transform
    private float speed = 200f; // Movement speed
    private float nextWaypointDistance = 3f; // Distance to switch to the next waypoint
    private float repathRate = 0.5f; // How often to update the path
    private Seeker seeker; // A* Pathfinding Seeker component
    private Path path; // Current path
    private int currentWaypoint = 0; // Current waypoint index
    private bool reachedEndOfPath = false; // Whether the enemy reached the end of the path
    private Rigidbody2D rb;

    private float timer;
    private EnemyAISO enemyAISO;
    public EnemyMoveBehaviour(EnemyStateMachine machine)
    {
        this.machine = machine;
    }
    public override void OnEnter()
    {
        seeker = machine.GetComponent<Seeker>();
        rb = machine.GetComponent<Rigidbody2D>();
        target = GameManager.Instance.Player.transform;
        enemyAISO = machine.EnemyAISO;
 
    }
    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if(timer > enemyAISO.RepathRate)
        {
            UpdatePath();
            timer = 0;
        }
        if(path == null) return;
        Move();
    }
    private void Move()
    {
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)machine.transform.position).normalized;
        Vector2 velocity = direction * enemyAISO.Speed;

        if(Vector2.Distance(machine.transform.position, target.position) <= enemyAISO.StopDistance)
        {
            velocity = Vector2.zero;
        }
        rb.velocity = velocity;

        float distance = Vector2.Distance(machine.transform.position, path.vectorPath[currentWaypoint]);
        if(distance < enemyAISO.NextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
    private void UpdatePath()
    {
        if(seeker.IsDone())
        {
            path = seeker.StartPath(machine.transform.position, target.position, OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
