using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float moveInAxisX;
    private float moveInAxisY;
    private Rigidbody2D rBody;

    void Start()
    {
        speed = 10.0f;
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInAxisX = Input.GetAxis("Vertical");
        moveInAxisY = Input.GetAxis("Horizontal");

       Vector2 speedVector = new Vector2(moveInAxisY, moveInAxisX);
       rBody.velocity = speedVector.normalized * speed;
    }
}
