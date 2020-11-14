using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;
    public float vitessePlayer = 5;
    public float jumpForce = 5;
    public SpriteRenderer rend;

    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * vitessePlayer;

        rb.velocity = new Vector2(h, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();            
        }

        if(h > 0)
        {
            rend.flipX = false;
        }
        if(h < 0)
        {
            rend.flipX = true;
        }
    }

    void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
 
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Grounded"))
        {
            isGrounded = false;
        }
    } 

}