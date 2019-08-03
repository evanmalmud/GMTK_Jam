using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardEntry : MonoBehaviour
{
    public TextMeshProUGUI RankText;
    public TextMeshProUGUI PseudoText;
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        SetInfos("", "", "");
    }
    
    public void SetInfos(string rank, string pseudo, string score) {
        RankText.text = rank;
        PseudoText.text = pseudo;
        ScoreText.text = score;
    }
}
