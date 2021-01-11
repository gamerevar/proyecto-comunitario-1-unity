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
    [Tooltip("Drone movement speed.")]
    [SerializeField] private float speed = 10;
    [Tooltip("Maximun distance before the Drone starts moving.")]
    [SerializeField] private float distance = 1;
    [Tooltip("Offset added to the player position.")]
    [SerializeField] private Vector3 offset = Vector3.zero;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rBody = GetComponent<Rigidbody2D>();
        offset.z = 0; //Un z = 0 puede causar problemas en un juego 2D.
    }
    
    void Update()
    {
        dirInX = player.position.x + offset.x - transform.position.x;
        dirInY = player.position.y + offset.y - transform.position.y;

        Vector2 dir = new Vector2(dirInX, dirInY) * Time.fixedDeltaTime;

        distanceToPlayer = Vector2.Distance(transform.position, player.position + offset);

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
