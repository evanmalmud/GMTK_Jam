using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DestroyOnTouch : MonoBehaviour
{

    [TagSelector]
    public string[] TagFilterArray = new string[] { };

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in TagFilterArray)
        {
            if (collision.gameObject.tag.Equals(tag))
            {
                // Destroy
                Destroy(collision.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
