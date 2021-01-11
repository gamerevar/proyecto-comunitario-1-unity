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
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       moveInAxisX = Input.GetAxisRaw("Vertical");
       moveInAxisY = Input.GetAxisRaw("Horizontal");

       Vector2 directionVector = new Vector2(moveInAxisY, moveInAxisX);
       rBody.velocity = directionVector.normalized * speed;
    }
}
