using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialForce : MonoBehaviour
{

    Rigidbody2D rb;
    public int forceVal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * forceVal);
    }

    private void Update()
    {
        print(rb.velocity.magnitude);
    }
}
