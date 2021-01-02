using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rBody;
    private float distanceInX;
    private float distanceInY;
    [SerializeField] private float speed;
    [SerializeField] private float distance;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        distanceInX = player.position.x - transform.position.x;
        distanceInY = player.position.y - transform.position.y;

        distanceInX *= Time.fixedDeltaTime;
        distanceInY *= Time.fixedDeltaTime;

        Vector2 dir = new Vector2(distanceInX, distanceInY);

        if (Vector2.Distance(transform.position, player.position) < distance + 0.05f && Vector2.Distance(transform.position, player.position) > distance)
        {
            rBody.velocity = Vector2.zero;
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) > distance)
            {
                rBody.velocity = dir * speed;
            }
            else
            {
                if (Vector2.Distance(transform.position, player.position) < distance)
                {
                    rBody.velocity = dir * -speed;
                }
            }
        }
    }
}
