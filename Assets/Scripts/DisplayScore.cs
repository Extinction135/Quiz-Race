using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text displayScore;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        displayScore.text = gameManager.score.ToString();
        Debug.Log(gameManager.score);
    }
}
