using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que maneja proyectiles compuestos por un RigidBody2D y un Collider2D.
/// Funciona tanto para proyectiles del jugador como del enemigo, para esto la layer del proyectil debe ser o PlayerBullet o EnemyBullet.
/// </summary>
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int proyectileDamage = 20;

    [SerializeField]
    private float proyectileVelocity = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(proyectileDamage);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage(proyectileDamage);
        }        
        Destroy(gameObject);
    }

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * proyectileVelocity;
    }
}
