using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDeath : MonoBehaviour
{

    [TagSelector] public string[] TagFilterArray;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in TagFilterArray)
        {
            if (other.gameObject.tag.Equals(tag))
            {
                if (GameManager.GetInstance().IsGameActive())
                {
                    GameManager.GetInstance().EndGame();
                }
            }
        }
    }
}
