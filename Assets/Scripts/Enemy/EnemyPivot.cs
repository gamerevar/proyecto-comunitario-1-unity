using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rota el objeto en el que esta asignado para apuntar hacia el jugador.
/// Se suele usar en un objeto hijo de un Enemigo.
/// </summary>
public class EnemyPivot : MonoBehaviour
{
    private Camera cam;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = Camera.main;
    }

    void Update()
    {
        var dir = player.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
