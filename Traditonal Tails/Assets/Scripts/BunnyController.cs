using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float limits = 3f;
    public BunnyState State = BunnyState.Hovering;

    public Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (State == BunnyState.Hovering)
        {
            MoveBunny();
        }

        if (Input.GetKeyDown(KeyCode.Space) && State == BunnyState.Hovering)
        {
            // activate rigidbody
            rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            // change state to dropped
            State = BunnyState.Dropped;
        }
    }

    void MoveBunny()
    {
        // Use Rigidbody2D to move the bunny
        float horizontalInput = Mathf.Sin(Time.time * moveSpeed);
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rigidbody2D.position = movement * limits;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny"))
        {
            StackBunny(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("StackableSurface"))
        {
            State = BunnyState.Stacked;
            FindObjectOfType<GameManager>().BunnyStacked();
            rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

            FindObjectOfType<GameManager>().SpawnBunny();
        }
    }

    void StackBunny(GameObject otherBunny)
    {
        float yOffset = 0.5f;
        transform.position = new Vector2(otherBunny.transform.position.x, otherBunny.transform.position.y + yOffset);
    }
}