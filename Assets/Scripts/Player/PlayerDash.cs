using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script encargado de darle la capacidad a un objeto de dashear a la direccion en la que se mueve.
/// </summary>
public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Distancia recorrida al hacer un dash")]
    private float dashDistance;

    [SerializeField]
    [Tooltip("Tiempo de recarga del Dash")]
    private float dashCouldown;

    // Para controlar el couldown del dash
    private float couldownCounter;
    private bool canDash;

    private void Start()
    {
        canDash = false;
        couldownCounter = dashCouldown;
    }

    private void Update()
    {
        if (canDash)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                canDash = false;
                couldownCounter = 0;
                Dash();
            }
        }
        else
        {
            couldownCounter += Time.deltaTime;
            if (couldownCounter >= dashCouldown)
                canDash = true;
        }
    }

    private void Dash()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        Vector3 dashDirection = new Vector3(hAxis, vAxis);
        dashDirection = dashDirection.normalized * dashDistance;

        transform.Translate(dashDirection);
    }
}
