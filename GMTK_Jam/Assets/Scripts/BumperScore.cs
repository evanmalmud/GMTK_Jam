using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BumperScore : MonoBehaviour
{
    public int ScorePoints;

    private void OnCollisionEnter2D(Collision2D other) {
        AudioManager.instance.Play("Bumper " + new System.Random().Next(2));
        GameManager.GetInstance().IncreaseScore(other.GetContact(0).point, ScorePoints);
    }
}
