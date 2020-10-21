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
        string startGameSceneName = "StartGameScene";
        SceneManager.LoadScene(startGameSceneName);
    }

    public void RestartGame()
    {
        // Reload the level
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene != null)
        {
            string easyPlayerSceneName = "EasyPlayerScene";
            string normalPlayerSceneName = "NormalPlayerScene";
            if (easyPlayerSceneName.Equals(activeScene.name))
            {
                SceneManager.LoadScene(easyPlayerSceneName);
            }
            else if (normalPlayerSceneName.Equals(activeScene.name))
            {
                SceneManager.LoadScene(normalPlayerSceneName);
            }
        }
    }
}
