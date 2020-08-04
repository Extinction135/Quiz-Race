using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    private CharacterController playerCarController;
    private Vector3 direction;

    public float speed;

    public GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        playerCarController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManger.speed <0)
        {
            speed = 0;
        }
        else
        {
            speed = gameManger.speed;

        }


        //speed = gameManger.speed;      
        direction.x = speed;
        Debug.Log(gameManger.speed);
    }

    private void FixedUpdate()
    {
        playerCarController.Move(direction * Time.fixedDeltaTime);
    }
}
