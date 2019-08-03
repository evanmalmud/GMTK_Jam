using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreTextPoints : MonoBehaviour
{
    private TextMeshProUGUI text;

    private static readonly int ScoreUpdate = Animator.StringToHash("ScoreUpdate");

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "0";
    }
    
    public void UpdateScoreText(int score) {
        text.text = score.ToString();
        if(GetComponent<Animator>())
            GetComponent<Animator>().SetTrigger(ScoreUpdate);
    }
}
