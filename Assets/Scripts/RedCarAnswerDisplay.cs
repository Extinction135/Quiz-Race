using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarAnswerDisplay : MonoBehaviour
{
    

    private void Update()
    {
        GetComponent<TextMesh>().text = RedCarController.redCarAnswerDisplay;
        if (RedCarController.redCarAnswerDisplay == "CORRECT")
        {
            GetComponent<TextMesh>().color = Color.green;
        }
        else
        {
            GetComponent<TextMesh>().color = Color.red;
        }



    }

}
