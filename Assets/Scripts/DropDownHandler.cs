using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DropDownHandler : MonoBehaviour
{
    public TextMeshProUGUI dropdown;

    public static int dd_value;

    public void HandleInputData(int val)
    {
        if (val == 1)
        {
            dd_value = 1;


        }
        if (val == 2)
        {
            dd_value = 2;

        }
        if (val == 3)
        {
            dd_value = 3;

        }
        Debug.Log(val);

    }


}
