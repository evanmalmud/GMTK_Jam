using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(Animator))]
public class MultiplierText : MonoBehaviour
{
    public TextMeshProUGUI text;

    private Animator _animator;

    private int multiplierSongIndex;
    private int lastMultiplier;

    private static readonly int MultiplierUpdate = Animator.StringToHash("Update");

    // Start is called before the first frame update
    void Start()
    {
        text.text = "0x";
        _animator = GetComponent<Animator>();
    }

    public void UpdateMultiplier(int multiplier, bool justText = false)
    {
        text.text = multiplier + "x";

        if (multiplier > lastMultiplier)
        {
            AudioManager.instance.Play("Multiplier " + multiplierSongIndex);
        
            multiplierSongIndex = (multiplierSongIndex + 1) % 2;
            _animator.SetTrigger(MultiplierUpdate);
        }

        lastMultiplier = multiplier;
    }
}
