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
    public int GetScore() { return score; }
    public void IncreaseScore(int amount) {
        score += amount;

        ScoreTextPoints sp = GameObject.FindObjectOfType<ScoreTextPoints>();
        if(sp != null) {
            sp.UpdateScoreText(score);
        }
    }

    private int basicEnemiesDefeated;
    public int GetBasicEnemeiesDefeated() { return basicEnemiesDefeated; }
    public void IncreaseBasicEnemeiesDefeated() { basicEnemiesDefeated += 1; }

    private int mediumEnemiesDefeated;
    public int GetMediumEnemeiesDefeated() { return mediumEnemiesDefeated; }
    public void IncreaseMediumEnemeiesDefeated() { mediumEnemiesDefeated += 1; }


    private void Start() {
        IncreaseScore(0);
    }
}
