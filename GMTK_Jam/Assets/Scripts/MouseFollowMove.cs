using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseFollowMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 350f;
    [SerializeField] float RotateSpeed = 2000f;

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
            // TODO: We could add some sort of check to see if you are moving away from or towards the object
            // Currently if the missile drives by your mouse its a little confused. The corss product at the time is
            // the same if you are headed directly away or to the target.

            // Set the velocity - Currently this is just a base speed, 
            // but once things are calling the Speed up/down functions this will change
            rb.velocity = transform.up * MoveSpeed * Time.deltaTime;

            // This gets the difference in world position from the mouse to the gameobject this script is on
            Vector3 targetVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            // Cross product takes two vectors and finds the perpendicular vector
            // For example if you had the two vectors (1,0,0) and (0,1,0) the Cross would be (0,0,1)
            // Then once we have the cross product we are only taking the z value. 
            // This gives us a neumerical value to use for the angle instead of a vector2 or 3
            //Debug.LogFormat("targetVector: {0} - Cross: {1}", targetVector, Vector3.Cross(targetVector, transform.up));
            float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;

            // Then we add this to the angular velocity and multiplyit by how fast we want to turn.
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
