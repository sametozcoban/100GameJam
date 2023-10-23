using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ForDestroy : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (GameObject.FindGameObjectWithTag("Haydar").GetComponent<HaydarControl>().isFlip)
        {
            rb.velocity = new Vector2(-30f, 0f);
            transform.position = new Vector2(GameObject.FindGameObjectWithTag("shotSpawn").transform.position.x + -1f, GameObject.FindGameObjectWithTag("shotSpawn").transform.position.y + -.12f);
        }
        if (!GameObject.FindGameObjectWithTag("Haydar").GetComponent<HaydarControl>().isFlip)
        {
            rb.velocity = new Vector2(30f, 0f);
        }
        
        Destroy(gameObject,2f);
    }


}
