using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarController : MonoBehaviour
{
    private CharacterController redCarController;
    private Vector3 direction;

    public static float speed;

    public int randomNumber;

    public int randomTime;

    public static string redCarAnswerDisplay;



    // Start is called before the first frame update
    void Start()
    {
        speed = 0.0f;
        redCarController = GetComponent<CharacterController>();
        StartCoroutine(RedCarMove());

    }

    IEnumerator RedCarAnswerDisplayTimer()
    {
        yield return new WaitForSeconds(1);
        redCarAnswerDisplay = " ";


    }


    IEnumerator RedCarMove()
    {
        for (; ; )
        {
            randomTime = Random.Range(2, 9);
            Debug.Log(randomTime);

            yield return new WaitForSeconds(randomTime);

            randomNumber = Random.Range(0, 101);
            if (randomNumber >= 0 && randomNumber <= 20)
            {
                speed = speed - 0.5f;
                if (speed < 0)
                {
                    speed = 0;
                }
                Debug.Log(randomNumber);
                Debug.Log(speed);
                redCarAnswerDisplay = "WRONG";
                StartCoroutine(RedCarAnswerDisplayTimer());
                Debug.Log(redCarAnswerDisplay);
                direction.x = speed;
            }
            else
            {
                speed = speed + 1.0f;
                Debug.Log(speed);
                Debug.Log(randomNumber);
                redCarAnswerDisplay = "CORRECT";
                StartCoroutine(RedCarAnswerDisplayTimer());
                Debug.Log(redCarAnswerDisplay);
                direction.x = speed;

            }



        }

    }



    private void FixedUpdate()
    {
        redCarController.Move(direction * Time.fixedDeltaTime);
    }
}
