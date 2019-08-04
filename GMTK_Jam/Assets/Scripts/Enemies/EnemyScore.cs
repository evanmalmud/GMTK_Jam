using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyScore : MonoBehaviour
{
    public int ScorePoints;

    private void OnCollisionEnter2D(Collision2D other)
    {
        //TODO Enemy Sounds

        //AudioManager.instance.Play("Enemy " + new System.Random().Next(2));
        GameManager.GetInstance().IncreaseScore(other.GetContact(0).point, ScorePoints);
    }
}