using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que controla los estados del enemigo, lo mueve y tambien incluye su sistema de vida.
/// </summary>
public class Enemy : MonoBehaviour
{
    public EnemyData data;
    
    private int maxHealth;
    private float movementSpeed;
    private float attackRange;
    private float aggroRange;

    public enum State { Idle, Moving, Attacking };

    private int health;
    private bool alive;
    
    private Transform player;
    private PlayerHealth playerHealth;
    private State state;
    private EnemyAttack enemyAttack;

    private void Awake()
    {
        LoadScriptableObjectData();
        health = maxHealth;
        alive = true;
    }

    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
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
                if (playerDistance <= attackRange)
                {
                    if (enemyAttack.AttackReady())
                    {
                        Attack();
                    }
                    else
                    {
                        break; //Para que el enemigo no empuje al jugador
                    }
                }                   
                else if (playerDistance > aggroRange)
                {
                    state = State.Idle;
                }
                else
                {
                    MoveTowardsPlayer();
                }                  
                break;
            case State.Attacking:
                if (!enemyAttack.MovementRestrained())
                {
                    state = State.Idle;
                }
                break;
        }
    }

    private void Attack()
    {
        enemyAttack.Attack(playerHealth);
        state = State.Attacking;
    }

    private void LoadScriptableObjectData()
    {
        maxHealth = data.maxHealth;
        movementSpeed = data.movementSpeed;
        aggroRange = data.aggroRange;

        attackRange = data.attackData.attackRange;
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
