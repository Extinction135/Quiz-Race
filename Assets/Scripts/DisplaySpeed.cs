using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySpeed : MonoBehaviour
{
    public Text displaySpeed;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displaySpeed.text = gameManager.speed.ToString() + " m/s";
        Debug.Log(gameManager.speed);
    }
}
