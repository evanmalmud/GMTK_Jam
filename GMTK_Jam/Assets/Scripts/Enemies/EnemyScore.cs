using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyScore : MonoBehaviour
{
    public int ScorePoints;
    public bool IsMedium;
    [TagSelector] public string PlayerTag;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // very easy way for double hit
        if (other.collider.CompareTag(PlayerTag))
        {
            AudioManager.instance.Play("Hurt " + new System.Random().Next(5));

            if (IsMedium)
            {
                IsMedium = false;
            } else
            {
                GameManager.GetInstance().IncreaseScore(other.GetContact(0).point, ScorePoints);
                Destroy(gameObject);
            }
        }
    }
}