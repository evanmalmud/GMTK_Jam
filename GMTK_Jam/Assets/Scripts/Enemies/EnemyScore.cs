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
        Debug.Log(IsMedium);
        // very easy way for double hit
        if (other.collider.CompareTag(PlayerTag))
        {
            //TODO Enemy hurt Sounds
            //AudioManager.instance.Play("Enemy " + new System.Random().Next(2));

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