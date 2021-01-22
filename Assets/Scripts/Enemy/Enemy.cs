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
    }

    private void Update()
    {
        if (!alive)
            return;

        float playerDistance = Vector3.Distance(player.position, transform.position);

        switch (state)
        {
            case State.Idle:
                if (playerDistance <= aggroRange)
                    state = State.Moving;

                break;
            case State.Moving:
                MoveTowardsPlayer();

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

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
    }

    public void Damage(int amount)
    {
        if (!alive) return;

        health -= amount;

        if(health <= 0) Kill();
    }
}
