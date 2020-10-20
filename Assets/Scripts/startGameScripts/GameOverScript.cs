using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    private Button[] buttons;

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        // Reload the level
        SceneManager.LoadScene("StartGameScene");
    }

    public void RestartGame()
    {
        // Reload the level
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene != null)
        {
            if ("EasyPlayerScene".Equals(activeScene.name))
            {
                SceneManager.LoadScene("EasyPlayerScene");
            }
            else if ("NormalPlayerScene".Equals(activeScene.name))
            {
                SceneManager.LoadScene("NormalPlayerScene");
            }
        }
    }
}
