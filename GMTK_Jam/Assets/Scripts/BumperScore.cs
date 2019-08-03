using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BumperScore : MonoBehaviour
{
    public int ScorePoints;

    private void OnCollisionEnter2D(Collision2D other) {
        GameManager.GetInstance().IncreaseScore(ScorePoints);

        if(FindObjectOfType<ScorePointsSpawn>())
            FindObjectOfType<ScorePointsSpawn>().AddScorePoint(other.contacts[0].point, ScorePoints);
    }
}
