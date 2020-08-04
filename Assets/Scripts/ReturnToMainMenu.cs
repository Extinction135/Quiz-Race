using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
   public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        if (DropDownHandler.dd_value == 1)
        {
            SceneManager.LoadScene("Game");
        }
        if (DropDownHandler.dd_value == 2)
        {
            SceneManager.LoadScene("Game 1");
        }
        if (DropDownHandler.dd_value == 3)
        {
            SceneManager.LoadScene("Game 2");
        }

    }
}
