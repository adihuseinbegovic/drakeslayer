﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");       
    }

    // Quit Game!
    public void ExitGame()
    {
        Application.Quit();
    }
}
