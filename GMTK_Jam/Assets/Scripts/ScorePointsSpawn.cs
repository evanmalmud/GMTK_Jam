using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointsSpawn : MonoBehaviour
{

    public GameObject ScorePointPrefab;

    public void AddScorePoint(Vector3 position, int points)
    {
        GameObject instance = Instantiate(ScorePointPrefab, transform);
        //TODO Issue with UI render distance. Taking the easy fix
        instance.transform.position = new Vector3( position.x, position.y, -10);
        instance.GetComponent<ScorePoint>().SetTextAndDestroy(null, points.ToString());
    }
}
