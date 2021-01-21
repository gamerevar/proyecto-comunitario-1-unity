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
        door.GetComponent<SpriteRenderer>().sprite = doorCloseSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;

        door.GetComponent<SpriteRenderer>().sprite = doorOpenSprite;
        door.GetComponent<BoxCollider2D>().enabled = false;
    }
}
