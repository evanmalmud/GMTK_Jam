using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BumperScore : MonoBehaviour
{
    public int ScorePoints;

    #pragma warning disable 108,114
    private GameObject Light;
    #pragma warning restore 108,114
    private readonly float lightPause = 0.2f;

    private void Start()
    {
        if (transform.childCount > 0)
        {
            Light = transform.GetChild(0).gameObject;
            Light.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        AudioManager.instance.Play("Bumper " + new System.Random().Next(2));
        GameManager.GetInstance().IncreaseScore(other.GetContact(0).point, ScorePoints);

        StartCoroutine(OnAndOff());
    }

    IEnumerator OnAndOff()
    {
        if (Light)
        {
            Light.SetActive(true);
            yield return new WaitForSeconds(lightPause);
            Light.SetActive(false);
            yield return new WaitForSeconds(lightPause);
            Light.SetActive(true);
            yield return new WaitForSeconds(lightPause);
            Light.SetActive(false);
        }
    }
}
