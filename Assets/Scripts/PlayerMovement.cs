using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float powerjump;
    private bool grounded = true;
    private int powercount = 5;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
 
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            if (Input.GetKey(KeyCode.F) && powercount > 0)
            {
                jumpwithpower();
                powercount--;
            }
            else
            {
                jumpon();
            }
        }
    }

    private void jumpon()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        grounded = false;
    }

    private void jumpwithpower()
    {
        body.velocity = new Vector2(body.velocity.x, powerjump);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
