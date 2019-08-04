using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRequests : MonoBehaviour
{
    public string[] results;
    // Start is called before the first frame update
    void Awake()
    {
        DownloadScores();
    }

    IEnumerator IEDownloadScores()
    {
        
        #pragma warning disable 0618
        WWW request = new WWW("http://dreamlo.com/lb/5d4548ac7682801758e56f55/pipe/0/7");
        //Debug.Log("Started Downloading leaderboard");
        #pragma warning restore 0618
        
        yield return request;

        if (string.IsNullOrEmpty (request.error)) {
            Debug.Log("leaderboard downloaded");
            string result = request.text;
            Debug.Log(result);
            results = result.Split('\n');
            
            if(FindObjectOfType<ScoreCanvasScript>())
                FindObjectOfType<ScoreCanvasScript>().ShowEntries();
        }
        else
        {
            Debug.LogWarning("Failed downloading the leaderboard");
        }
    }
    
    IEnumerator UploadNewHighscore(string username, int score) {
        #pragma warning disable 0618
        WWW www = new WWW("http://dreamlo.com/lb/uEuQco4nukidyS_1ZkyNqgcO6gNWYLD0C0baODBF1ebA/add/" + WWW.EscapeURL(username) + "/" + score);
        #pragma warning restore 0618
        
        yield return www;

        if (string.IsNullOrEmpty(www.error)) {
            print ("Upload Successful");
            Debug.Log(www.text);
            DownloadScores();
        }
        else {
            print ("Error uploading: " + www.error);
        }
    }

    public void UploadHighScore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    public void DownloadScores()
    {
        StartCoroutine(nameof(IEDownloadScores));
    }
}
