using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField]
    private int proyectileDamage;

    [SerializeField]
    private float proyectileVelocity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;

        collision.gameObject.GetComponent<Enemy>().Damage(proyectileDamage);
        Destroy(gameObject);
    }

    private void Start()
    {
        Vector3 mouseDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        GetComponent<Rigidbody2D>().velocity = mouseDirection.normalized * proyectileVelocity;
    }
}
