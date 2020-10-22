﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("PlayerSelectionScene");       
    }

    // Quit Game!
    public void ExitGame()
    {
        Application.Quit();
    }
}
