using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sistema simple de movimiento para el jugador.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float moveInAxisX;
    private float moveInAxisY;

    private Rigidbody2D rBody;
    private PlayerHealth playerHealth;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (playerHealth.IsAlive())
        {
            moveInAxisX = Input.GetAxisRaw("Vertical");
            moveInAxisY = Input.GetAxisRaw("Horizontal");

            Vector2 directionVector = new Vector2(moveInAxisY, moveInAxisX);
            rBody.velocity = directionVector.normalized * speed;
        }
    }
}
