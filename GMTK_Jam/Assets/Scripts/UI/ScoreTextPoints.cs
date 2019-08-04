using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(Animator))]
public class ScoreTextPoints : MonoBehaviour
{
    private TextMeshProUGUI text;

    private static readonly int ScoreUpdate = Animator.StringToHash("Update");


    private void OnEnable()
    {
        ResetScore();
    }
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        ResetScore();
    }
    
    public void UpdateScoreText(int score) {
        text.text = score.ToString();
        if(GetComponent<Animator>())
            GetComponent<Animator>().SetTrigger(ScoreUpdate);
        AudioManager.instance.Play("ScoreUp");
    }

    public void ResetScore()
    {
        text.text = "0";
    }
}
