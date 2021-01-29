using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script encargado de rotar un pivote hacia la posicion del mouse.
/// </summary>
public class RotateTowardsMouse : MonoBehaviour
{
    private Camera cam;

    Vector3 mousePos;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        var dir = mousePos - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
