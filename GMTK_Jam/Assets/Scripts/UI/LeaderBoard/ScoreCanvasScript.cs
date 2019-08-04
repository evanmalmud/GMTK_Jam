using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCanvasScript : MonoBehaviour
{

    private string[] infos;

    public GameObject[] LeaderboardEntries;

    private void OnEnable()
    {
        if(FindObjectOfType<ScoreRequests>())
            FindObjectOfType<ScoreRequests>().DownloadScores();
    }

    private void ClearEntries()
    {
        foreach (GameObject leaderboardEntry in LeaderboardEntries)
        {
            leaderboardEntry.GetComponentInChildren<TextMeshProUGUI>().text = "...";
        }
    }

    public void ShowEntries()
    {
        ClearEntries();
        
        string[] arr = FindObjectOfType<ScoreRequests>().results;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i].Length > 1)
            {
                infos = arr[i].Split('|');
                if (infos.Length >= 2)
                    LeaderboardEntries[i].GetComponentInChildren<TextMeshProUGUI>().text =
                        infos[0].ToUpper() + " : " + infos[1];
            }
        }

    }
    public void OnEnterScore() {
        string pseudo = FindObjectOfType<PseudoLeaderboardEntry>().GetPseudo();
        if(pseudo.Length > 2 && FindObjectOfType<ScoreRequests>()) {
            FindObjectOfType<ScoreRequests>().UploadHighScore(pseudo, GameManager.GetInstance().GetScore());
        }
    }
}
