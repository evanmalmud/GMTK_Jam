using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    public static GameManager GetInstance() {
        if(instance == null)
            instance = new GameManager();
        
        return instance;
    }

    private int score;

    private void Start() {
        IncreaseScore(0);
    }

    public void IncreaseScore(int amount) {
        score += amount;

        ScoreTextPoints sp = GameObject.FindObjectOfType<ScoreTextPoints>();
        if(sp != null) {
            sp.UpdateScoreText(score);
        }
    }

    public int GetScore() {
        return score;
    }
}
