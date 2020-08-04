using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameManager gameManager;

    //private string Name;
    public static string playerName;
    private string Name;
    private int score;
    private string win;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScaA7rI3xE5xwoPDuQrqTVt5OdDrPEhEmkbmA0SVmgy2OkzTg/formResponse";

    IEnumerator Post(string Name, float score, string win)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.807188019", Name);
        form.AddField("entry.2018793885", score.ToString());
        form.AddField("entry.503141044", win);
        byte[] rawData = form.data;
        WWW wWW = new WWW(BASE_URL, rawData);
        yield return wWW;
    }

    public void Send()
    {
        //Name = username.GetComponent<InputField>().text;

        Name = playerName;
        score = gameManager.score;

        win = "No";

        StartCoroutine(Post(Name, score, win));
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "FinishLine")
        {
            PlayerPrefs.SetInt("Score", gameManager.score);
            Debug.Log("Saved: " + PlayerPrefs.GetInt("Score").ToString());
            Send();
            SceneManager.LoadScene("RedCarFinish");
        }
    }
}
