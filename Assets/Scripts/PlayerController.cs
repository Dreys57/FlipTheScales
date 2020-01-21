using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    private Vector3 startPos;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        startPos = transform.position;
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(5f, body.velocity.y);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (body.gravityScale > 0)
            {
                body.gravityScale -= 8;
            }
            else
            {
                body.gravityScale += 8;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Spikes"))
        {
            transform.position = startPos;
        }
    }
}
