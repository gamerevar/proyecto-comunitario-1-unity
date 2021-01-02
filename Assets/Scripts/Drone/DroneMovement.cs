using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rBody;
    private float dirInX;
    private float dirInY;
    private float distanceToPlayer;
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        dirInX = player.position.x - transform.position.x;
        dirInY = player.position.y - transform.position.y;

        dirInX *= Time.fixedDeltaTime;
        dirInY *= Time.fixedDeltaTime;

        Vector2 dir = new Vector2(dirInX, dirInY);

        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < distance + 0.05f && distanceToPlayer > distance)
        {
            rBody.velocity = Vector2.zero;
        }
        else
        {
            if (distanceToPlayer > distance)
            {
                rBody.velocity = dir * speed;
            }
            else
            {
                    rBody.velocity = dir * -speed;
            }
        }
    }
}
