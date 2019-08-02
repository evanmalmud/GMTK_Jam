using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusTime : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }
    
    public void UpdatePercent(float value) {
        float correctedValue = Mathf.Clamp(value, 0f, 1f);

        image.fillAmount = correctedValue;
    }
}