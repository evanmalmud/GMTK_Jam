using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointsSpawn : MonoBehaviour
{

    public GameObject ScorePointPrefab;

    public int totalScore = 0;

    [SerializeField]
    public MultiplierEntry multipliers;

    public int currentMultiplier = 1;

    public float countDownMulti = 0.0f;


    private void Update()
    {
       if(countDownMulti <= 0)
       {
            clearMultiplier();
       }
    }

    public void AddScorePoint(Vector2 position, int points) {
        updateMultiplier();
        totalScore = +points;
        GameObject instance = Instantiate(ScorePointPrefab, transform);
        instance.transform.position = position;
        instance.GetComponent<ScorePoint>().SetTextAndDestroy(currentMultiplier + "X", points.ToString());
    }

    public void resetScore()
    {
        totalScore = 0;
    }

    void updateMultiplier()
    {
        
    }

    void clearMultiplier()
    {

    }
}
