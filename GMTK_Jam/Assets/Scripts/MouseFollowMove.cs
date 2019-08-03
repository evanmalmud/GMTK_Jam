using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollowMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 350f;
    [SerializeField] float RotateSpeed = 2000f;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * MoveSpeed * Time.deltaTime;

        Vector3 targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;

        rb.angularVelocity = -1 * rotatingIndex * RotateSpeed * Time.deltaTime;
    }
}
