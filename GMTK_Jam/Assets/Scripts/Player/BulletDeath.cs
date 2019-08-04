using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeath : MonoBehaviour
{

    [TagSelector] public string[] TagFilterArray;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in TagFilterArray)
        {
            if (other.gameObject.tag.Equals(tag))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnBecameInvisible()
    {
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (GameObject.FindObjectOfType<PlayerManager>())
            GameObject.FindObjectOfType<PlayerManager>().OnPlayerDestroy();
    }
}
