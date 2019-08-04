using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    //public GameObject pause;
    public GameObject gameOverMenu;

    private void Start()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.GetInstance().StartGame();
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void EndGame()
    {
        //enable gameOver Canvas
        gameOverMenu.SetActive(true);
    }
}
