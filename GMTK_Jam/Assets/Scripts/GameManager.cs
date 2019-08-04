using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    private int score;

    private bool isGameActive;
    public bool IsGameActive() { return isGameActive; }
    //TODO: Use this to start spawners

    private int basicEnemiesDefeated;
    public int GetBasicEnemeiesDefeated() { return basicEnemiesDefeated; }
    public void IncreaseBasicEnemeiesDefeated() { basicEnemiesDefeated += 1; }

    private int mediumEnemiesDefeated;
    public int GetMediumEnemeiesDefeated() { return mediumEnemiesDefeated; }
    public void IncreaseMediumEnemeiesDefeated() { mediumEnemiesDefeated += 1; }

    public static GameManager GetInstance()
    {
        if (instance == null)
            instance = new GameManager();

        return instance;
    }

    public int GetScore() { return score; }

    public void ResetScore(){
        score = 0;
    }

    public void IncreaseScore(Vector3 position, int amount)
    {
        if (GameObject.FindObjectOfType<MultiplierCalc>())
            GameObject.FindObjectOfType<MultiplierCalc>().UpdateMultiplier(1);

        score += amount * GameObject.FindObjectOfType<MultiplierCalc>().currentMultiplier;
        UpdateScore(score);

        if (GameObject.FindObjectOfType<ScorePointsSpawn>())
            GameObject.FindObjectOfType<ScorePointsSpawn>().AddScorePoint(position, amount);
    }

    public void StartGame()
    {
        ResetScore();
        ResetEnemiesDefeated();
        if (GameObject.FindObjectOfType<SpawnPointsController>())
            GameObject.FindObjectOfType<SpawnPointsController>().ResetBasicEnemyCount();
        isGameActive = true;
    }

    public void UpdateScore(int UpdateScore)
    {
        ScoreTextPoints sp = GameObject.FindObjectOfType<ScoreTextPoints>();
        if (sp != null)
        {
            sp.UpdateScoreText(UpdateScore);
        }
    }

    public void EndGame()
    {
        //Wait a few seconds so that we can play the GameOver anims
        isGameActive = false;
    }

    public void ResetEnemiesDefeated()
    {
        basicEnemiesDefeated = 0;
        mediumEnemiesDefeated = 0;
    }
}
