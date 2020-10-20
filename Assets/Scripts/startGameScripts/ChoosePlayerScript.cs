using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlayerScript : MonoBehaviour
{
    public void ChooseEasy()
    {
        SceneManager.LoadScene("EasyPlayerScene");
    }

    public void ChooseNormal()
    {
        SceneManager.LoadScene("NormalPlayerScene");
    }
}
