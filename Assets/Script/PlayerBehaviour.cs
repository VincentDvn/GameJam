using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;

    public float vitessePlayer = 5;
    public float jumpForce = 5;

    public SpriteRenderer rend;

    private float h;
    private float friction;

    private bool isGrounded = true;
    private bool isSlipping = false;
    private bool isRebond = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal") * vitessePlayer;

        if(isSlipping)
        {
            if(h == Mathf.Abs(vitessePlayer))
            {
                rb.velocity = new Vector2(h, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);                
            }
        }
        else
        {
            rb.velocity = new Vector2(h, rb.velocity.y);
        }
        
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
        if(isRebond)
        {
            rb.AddForce(transform.up * jumpForce * 2, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
 
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }
        if(coll.gameObject.CompareTag("PlancheGelée"))
        {
            isGrounded = true;
            isSlipping = true;
        }
        if(coll.gameObject.CompareTag("Ressort"))
        {
            isRebond = true;
            jump();
            isRebond = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Grounded"))
        {
            isGrounded = false;
        }
        if(coll.gameObject.CompareTag("PlancheGelée"))
        {
            isGrounded = false;
            isSlipping = false;
        }
    } 

}