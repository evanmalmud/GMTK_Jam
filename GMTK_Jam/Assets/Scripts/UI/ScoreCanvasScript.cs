using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCanvasScript : MonoBehaviour
{
    public int numberOfResults;

    public LeaderBoardHandler handler;

    private void OnEnable() {
        Time.timeScale = 0f;

        DownloadScores();
    }

    private void OnDisable() {
        Time.timeScale = 1f;
    }

    [System.Obsolete]
    IEnumerator DownLoadHighScoresFromDatabase() {
#pragma warning disable 0618
        WWW request = new WWW("http://dreamlo.com/lb/5d4548ac7682801758e56f55/pipe/0/" + WWW.EscapeURL(numberOfResults.ToString()));
#pragma warning restore 0618
        yield return request;

        if (string.IsNullOrEmpty (request.error)) {
			string result = request.text;
            string[] arr = result.Split('\n');
            string[] infos;

            handler.ClearEntries();
            for(int i = 0; i < arr.Length - 1; i++) {
                if(arr[i].Length > 1) {
                    infos = arr[i].Split('|');
                    if(infos.Length >= 2)
                        handler.addEntry("#" + (i+1).ToString(), infos[0].ToUpper(), infos[1]);
                }
            }
		}
    }
    
    public void OnEnterScore() {
        string pseudo = FindObjectOfType<PseudoLeaderboardEntry>().GetPseudo();
        if(pseudo.Length > 2) {
            StartCoroutine(UploadNewHighscore(pseudo.ToUpper(), GameManager.GetInstance().GetScore()));
        }
    }

    public void DownloadScores() {
        StartCoroutine("DownLoadHighScoresFromDatabase");
    }
    
    IEnumerator UploadNewHighscore(string username, int score) {
#pragma warning disable 0618
        WWW www = new WWW("http://dreamlo.com/lb/uEuQco4nukidyS_1ZkyNqgcO6gNWYLD0C0baODBF1ebA/add/" + WWW.EscapeURL(username) + "/" + score);
#pragma warning restore 0618
        yield return www;

		if (string.IsNullOrEmpty(www.error)) {
			print ("Upload Successful");
			DownloadScores();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}
}
