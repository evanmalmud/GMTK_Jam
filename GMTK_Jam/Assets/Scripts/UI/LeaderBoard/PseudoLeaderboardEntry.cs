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

    public void OnValueChange(string value)
    {
        value = value.ToUpper();
        
        // cleaning with only numeric characters
        string cleanString = "";
        foreach (char letter in value)
        {
            if (letter >= 'A' && letter <= 'Z')
            {
                cleanString += letter;
            }
        }
        
        if (cleanString.Length > 3)
            cleanString = cleanString.Substring(0, 3);

        input.text = cleanString;
    }

    public string GetPseudo() {
        return input.text;
    }
}
