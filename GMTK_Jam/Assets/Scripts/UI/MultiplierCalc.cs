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
    }

    public void UpdateMultiplier(int newDestroys)
    {
        currentEnemiesHit += newDestroys;
        if(currentMultiplier == 1 && currentEnemiesHit < enemiesPerMultiIncrease)
        {
            //Reset the counter because it is your first hit
            countDownMulti = timePerMultiIncrease;
        }
        else if ((currentEnemiesHit - (enemiesPerMultiIncrease * currentMultiplier))  > 0)
        {
            if (currentMultiplier >= maxMultiplier)
            {
                currentMultiplier = maxMultiplier;
                countDownMulti += timePerMultiIncrease/enemiesPerMultiIncrease;
            }
            else
            {
                //Increase by each factor if you break into the next level
                int increaseBy = (currentEnemiesHit / enemiesPerMultiIncrease) + 1 - currentMultiplier;
                currentMultiplier += increaseBy;
                countDownMulti += increaseBy * timePerMultiIncrease;
            }
        }
        
        if(FindObjectOfType<MultiplierText>())
            FindObjectOfType<MultiplierText>().UpdateMultiplier(currentMultiplier);
    }

    void ResetMultiplier()
    {
        currentMultiplier = 1;
        currentEnemiesHit = 0;
        countDownMulti = 0;
    }
}
