using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScorePoint : MonoBehaviour
{
    public float displayTime = 1.0f;
    // Start is called before the first frame update
    public void SetTextAndDestroy(String multiplierText, String points) {
        if(multiplierText != null)
        {
            GetComponent<TextMeshPro>().text = multiplierText + "  " + points;
        }
        else
        {
            GetComponent<TextMeshPro>().text = points;
        }
        StartCoroutine("WaitAndDestroy");
    }
    
    IEnumerator WaitAndDestroy() {
        yield return new WaitForSeconds(displayTime);
        Destroy(gameObject);
    }
}
