using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float aggroRange;

    public enum State { Idle, Moving, Attacking };

    private int health;
    private bool alive;
    
    private Transform player;
    private Vector2 waypoint;
    private State state;


    private void Awake()
    {
        health = maxHealth;
        alive = true;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        state = State.Idle;
        waypoint = transform.position;
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
