﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoad : MonoBehaviour
{

    // Start is called before the first frame update
    public void loadMainScene()
    {
        SceneManager.LoadScene("BulletTest2", LoadSceneMode.Additive);
    }
}
