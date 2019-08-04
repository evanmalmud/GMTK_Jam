﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    //public GameObject pause;
    public GameObject gameOverMenu;
    public GameObject SettingsMenu;
    public GameObject LeaderboardMenu;

    public GameObject ScoreUI;

    private void Start()
    {
        gameOverMenu.SetActive(false);
        ScoreUI.SetActive(false);
        LeaderboardMenu.SetActive(false);
        SetSettingsMenu(false);
        
        mainMenu.SetActive(true);
        
        SettingsMenu.GetComponent<MusicSettings>().LoadSettings();
    }

    public void StartGame()
    {
        GameManager.GetInstance().StartGame();
        
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        LeaderboardMenu.SetActive(false);
        SetSettingsMenu(false);
        
        ScoreUI.SetActive(true);
        
        AudioManager.instance.Pause("Menu Theme");
        AudioManager.instance.Play("Theme");
    }

    public void GoToLeaderBoard()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        LeaderboardMenu.SetActive(true);
        ScoreUI.SetActive(false);
        
        AudioManager.instance.Pause("Theme");
        AudioManager.instance.Play("Menu Theme");
    }

    public void GoToMainMenu()
    {
        LeaderboardMenu.SetActive(false);
        
        mainMenu.SetActive(true);
    }

    public void EndGame()
    {
        //enable gameOver Canvas
        gameOverMenu.SetActive(true);
        ScoreUI.SetActive(false);
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

    public void Exit()
    {
        Application.Quit();
    }
}