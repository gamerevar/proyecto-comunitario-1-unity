using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public Sprite doorOpenSprite;
    public Sprite doorCloseSprite;

    private void Start()
    {
        if(door == null)
        {
            Debug.LogError("No se asigno la puerta correspondiente en door");
            return;
        }
        door.GetComponent<SpriteRenderer>().sprite = doorCloseSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;

        door.GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
        door.GetComponent<Collider2D>().enabled = false;
    }
}
