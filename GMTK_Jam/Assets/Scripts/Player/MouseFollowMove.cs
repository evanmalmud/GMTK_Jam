﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollowMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 350f;
    [SerializeField] float RotateSpeed = 2000f;


    private float disabledRotSpeed = 10000f;
    public GameObject Diamond;

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
        Vector3 vector;
        if (!GameManager.GetInstance().IsGameActive())
        {
            return;
        }
        if (disableMovement)
        {
            disableMovementTimer -= Time.deltaTime;
            if (disableMovementTimer <= 0)
            {
                disableMovement = false;
                //Diamond.SetActive(true);
            }
            //Using the velocity from the bouce to change the direction of the bullet
            vector = rb.velocity;

            float rotatingIndex = Vector3.Cross(vector, transform.up).z;

            // Then we add this to the angular velocity and multiplyit by how fast we want to turn.
            rb.angularVelocity = -1 * rotatingIndex * disabledRotSpeed * Time.deltaTime;
        }
        else
        {
            // TODO: We could add some sort of check to see if you are moving away from or towards the object
            // Currently if the missile drives by your mouse its a little confused. The corss product at the time is
            // the same if you are headed directly away or to the target.

            // Set the velocity - Currently this is just a base speed, 
            // but once things are calling the Speed up/down functions this will change
            rb.velocity = transform.up * MoveSpeed * Time.deltaTime;

            //Vector3 vector2 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -7.0f);
            //print("mouse position " + Input.mousePosition);
            //print("vector2: " + vector2);
            Vector3 mouseVector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z);
            Vector3 screenToWorld = Camera.main.ScreenToWorldPoint(mouseVector);
            //Debug.Log(Camera.main.ScreenToWorldPoint(vector));
            //print(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            // This gets the difference in world position from the mouse to the gameobject this script is on
            vector = new Vector3(screenToWorld.x, screenToWorld.y, transform.position.z) - transform.position;

            // Cross product takes two vectors and finds the perpendicular vector
            // For example if you had the two vectors (1,0,0) and (0,1,0) the Cross would be (0,0,1)
            // Then once we have the cross product we are only taking the z value. 
            // This gives us a neumerical value to use for the angle instead of a vector2 or 3
            //Debug.LogFormat("targetVector: {0} - Cross: {1}", targetVector, Vector3.Cross(targetVector, transform.up));
            float rotatingIndex = Vector3.Cross(vector, transform.up).z;

            // Then we add this to the angular velocity and multiplyit by how fast we want to turn.
            rb.angularVelocity = -1 * rotatingIndex * RotateSpeed * Time.deltaTime;
        }

        
    }

    [TagSelector] public string[] TagFilterArray;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        foreach (string tag in TagFilterArray)
        {
            if (other.gameObject.tag.Equals(tag))
            {
                disableMovement = true;
                //Diamond.SetActive(false);
                disableMovementTimer = disableMovementDefaultVal;
            }
        }
    }
}
