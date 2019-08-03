using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointsSpawn : MonoBehaviour
{

    public GameObject ScorePointPrefab;

    public void AddScorePoint(Vector2 position, int points)
    {
        GameObject instance = Instantiate(ScorePointPrefab, transform);
        instance.transform.position = position;
        instance.GetComponent<ScorePoint>().SetTextAndDestroy(null, points.ToString());
    }
}
