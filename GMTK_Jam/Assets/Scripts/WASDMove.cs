using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WASDMove : MonoBehaviour
{
    // Normal Movements Variables
    public float moveSpeed;
    public float spinSpeed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * moveSpeed, 0.8f), 
            Mathf.Lerp(0, Input.GetAxis("Vertical") * moveSpeed, 0.8f));
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddTorque(spinSpeed);
        }


    }
}

