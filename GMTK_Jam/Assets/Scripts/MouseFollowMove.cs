using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollowMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 350f;
    [SerializeField] float RotateSpeed = 2000f;

    [SerializeField] GameObject Diamond;

    Rigidbody2D rb;

    bool disableMovement = false;
    float disableMovementTimer = 1.0f;
    [SerializeField] float disableMovementDefaultVal = 1.0f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(disableMovement)
        {
            disableMovementTimer -= Time.deltaTime;
            if(disableMovementTimer <= 0)
            {
                disableMovement = false;
                Diamond.SetActive(true);
            }
        }
        else
        {
            rb.velocity = transform.up * MoveSpeed * Time.deltaTime;
            Vector3 targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;
            rb.angularVelocity = -1 * rotatingIndex * RotateSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //disable movement
        disableMovement = true;
        Diamond.SetActive(false);
        disableMovementTimer = disableMovementDefaultVal;
    }
}
