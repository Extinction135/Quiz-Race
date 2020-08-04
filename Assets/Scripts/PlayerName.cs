using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public InputField playerName;
    public Button startButton;

    public static string displayName;

    public void StartGame()
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



        //SceneManager.LoadScene("Game");

        displayName = playerName.text;
        PlayerFinishScript.playerName = playerName.text;
        FinishScript.playerName = playerName.text;
        Debug.Log(playerName.text);
    }

    void Update()
    {
        if (string.IsNullOrEmpty(playerName.text) || (DropDownHandler.dd_value == 0))
        {
            Debug.Log("Input is empty");
            //startButton.enabled = false;
            startButton.gameObject.SetActive(false);
        }
        else
            //startButton.enabled = true;
            startButton.gameObject.SetActive(true);
    }
}
