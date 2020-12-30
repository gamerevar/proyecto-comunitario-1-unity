using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float speed;
    private float moveInAxisX;
    private float moveInAxisY;
    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100.0f;
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveInAxisX = Input.GetAxis("Vertical");
        moveInAxisY = Input.GetAxis("Horizontal");

        moveInAxisX *= Time.deltaTime;
        moveInAxisY *= Time.deltaTime;

        Vector2 speedVector = new Vector2(moveInAxisY, moveInAxisX);
        rBody.velocity = speedVector * speed;

    }
}
