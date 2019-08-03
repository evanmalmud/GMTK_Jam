using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
public class PseudoLeaderboardEntry : MonoBehaviour
{
    private TMP_InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<TMP_InputField>();
    }

    public void OnValueChange(string value) {
        if(value.Length > 3)
            input.text = value.Substring(0, 3);
    }
}
