using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierCalc : MonoBehaviour
{

    public int currentMultiplier = 1;
    public int currentEnemiesHit = 0;
    public float countDownMulti = 0.0f;

    public int maxMultiplier = 9;
    public float timePerMultiIncrease = 5.0f;
    public int enemiesPerMultiIncrease = 5;

    public int bumpersTouchPenaltyAtMultiplier = 6;

    private void Start()
    {
        ResetMultiplier();
    }

    private void Update()
    {
        if (countDownMulti <= 0)
        {
            ResetMultiplier();
        }
        else
        {
            countDownMulti -= Time.deltaTime;
        }
        print("currentEnemiesHit" + currentEnemiesHit);
        print("currentMultiplier" + currentMultiplier);
        print("countDownMulti" + countDownMulti);
    }

    public void UpdateMultiplier(int newDestroys)
    {
        print("UpdateMultiplier currentEnemiesHit" + currentEnemiesHit);
        print("UpdateMultiplier currentMultiplier" + currentMultiplier);
        print("UpdateMultiplier countDownMulti" + countDownMulti);

        currentEnemiesHit += newDestroys;
        if(currentMultiplier == 1 && currentEnemiesHit == 1)
        {
            //Reset the counter because it is your first hit
            countDownMulti = timePerMultiIncrease;
        }
        else if (currentEnemiesHit / enemiesPerMultiIncrease > currentMultiplier)
        {
            int increaseBy = currentEnemiesHit / enemiesPerMultiIncrease;
            print("increaseBy" + increaseBy);
            currentMultiplier += increaseBy;
            countDownMulti += increaseBy * timePerMultiIncrease;
        }
    }

    void ResetMultiplier()
    {
        currentMultiplier = 1;
        currentEnemiesHit = 0;
        countDownMulti = 0;
    }
}
