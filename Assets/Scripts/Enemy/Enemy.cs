using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData data;

    private int maxHealth;
    private float movementSpeed;
    private float attackRange;
    private float aggroRange;

    public enum State { Idle, Moving, Attacking };

    private int health;
    private bool alive;
    
    private Transform player;
    private Vector2 waypoint;
    private State state;


    private void Awake()
    {
        LoadScriptableObjectData();
        health = maxHealth;
        alive = true;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        state = State.Idle;
        waypoint = transform.position;
    }

    private void Update()
    {
        float playerDistance = Vector3.Distance(player.position, transform.position);

        switch (state)
        {
            case State.Idle:
                if (playerDistance <= aggroRange)
                    state = State.Moving;

                break;
            case State.Moving:
                transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);

                if (playerDistance <= attackRange)
                    Attack();
                else if (playerDistance > aggroRange)
                    state = State.Idle;

                break;
            case State.Attacking:
                // TODO: Integrar con EnemyAttack
                break;
        }
    }

    private void Attack()
    {
        state = State.Attacking;

        // TODO: Integrar con EnemyAttack
        Debug.Log("Attacking");
    }

    private void LoadScriptableObjectData()
    {
        maxHealth = data.maxHealth;
        movementSpeed = data.movementSpeed;
        attackRange = data.attackRange;
        aggroRange = data.aggroRange;
    }

    private void Kill()
    {
        alive = false;
    }

    private void MoveTowardsWaypoint()
    {
        transform.Translate(waypoint.normalized * movementSpeed * Time.deltaTime);
    }

    public void Damage(int amount)
    {
        if (!alive) return;

        health -= amount;

        if(health <= 0) Kill();
    }
}
