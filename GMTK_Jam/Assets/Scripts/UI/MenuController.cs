using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    //public GameObject pause;
    public GameObject gameOverMenu;
    public GameObject SettingsMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        
        SetSettingsMenu(false);
        
        SettingsMenu.GetComponent<MusicSettings>().LoadSettings();
    }

    public void StartGame()
    {
        GameManager.GetInstance().StartGame();
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        SetSettingsMenu(false);
        AudioManager.instance.Pause("Menu Theme");
        AudioManager.instance.Play("Theme");
    }

    public void EndGame()
    {
        //enable gameOver Canvas
        gameOverMenu.SetActive(true);
        SetSettingsMenu(false);
        Time.timeScale = 0f;
        AudioManager.instance.Pause("Theme");
        AudioManager.instance.Play("Game Over");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetSettingsMenu(!SettingsMenu.activeSelf);
        }
    }

    public void SetSettingsMenu(bool display)
    {
        SettingsMenu.SetActive(display);
        AudioManager.instance.SetLowpass(display);
        Time.timeScale = display ? 0f : 1f;
    }
}
