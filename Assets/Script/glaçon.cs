using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glaçon : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vitesse;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(vitesse, 0);
        }
        if(rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(-vitesse, 0);
        }
        if(rb.velocity.x == 0)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
