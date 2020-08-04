using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarSpeedDisplay : MonoBehaviour
{
    private RedCarController redCarController;

    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMesh>().text = RedCarController.speed.ToString() + " m/s";
    
    }
}
