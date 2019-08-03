using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCanvasScript : MonoBehaviour
{
    public int numberOfResults;

    public LeaderBoardHandler handler;

    private void OnEnable() {
        Time.timeScale = 0f;

        StartCoroutine("DownLoadHighScores");
    }

    [System.Obsolete]
    IEnumerator DownLoadHighScores() {
        WWW request = new WWW("http://dreamlo.com/lb/5d4548ac7682801758e56f55/pipe/1/" + WWW.EscapeURL(numberOfResults.ToString()));
        yield return request;

        if (string.IsNullOrEmpty (request.error)) {
			string result = request.text;
            string[] arr = result.Split('\n');
            Debug.Log(arr);
            foreach(string sentence in arr) {
                Debug.Log(sentence);
            }
		}
    }
}
