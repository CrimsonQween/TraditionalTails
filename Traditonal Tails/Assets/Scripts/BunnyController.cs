using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float limits = 3f;
    public BunnyState State = BunnyState.Hovering;
    private bool didSpawnNextBunny = false;

    public Rigidbody2D rigidbody2D;
    public Sprite[] bunnySprites; 
    private int currentSpriteIndex = 0;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        UpdateSprite();
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
        rigidbody2D.position = new Vector2(horizontalInput * limits, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny") && State == BunnyState.Dropped)
        {
            BunnyController other = collision.gameObject.GetComponent<BunnyController>();

            if (other.State == BunnyState.OffLimits)
            {
                //Go to Gameover
                SceneManager.LoadScene("GaameOver");
                Debug.Log("oops");
                return;
            }
            other.State = BunnyState.OffLimits;
            StackBunny();
        }
        else if (collision.gameObject.CompareTag("StackableSurface"))
        {
            if (GameManager.HasStackedOnGround)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
            else
            {
                StackBunny();
            }
        }
    }

    private void StackBunny()
    {
        GameManager.HasStackedOnGround = true;
        State = BunnyState.Stacked;
        
        // Increase the Score when a bunny is stacked
        FindObjectOfType<GameManager>().BunnyStacked();
            
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.angularVelocity = 0f;
        
        if (!didSpawnNextBunny)
        {
            FindObjectOfType<GameManager>().SpawnBunny();
            didSpawnNextBunny = true;
        }
    }
    
    private void UpdateSprite()
    {
        // Update the sprite based on the current index
        GetComponent<SpriteRenderer>().sprite = bunnySprites[currentSpriteIndex];
    }
    
}