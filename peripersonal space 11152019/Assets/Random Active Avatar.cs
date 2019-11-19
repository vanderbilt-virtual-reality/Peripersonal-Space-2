using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActiveAvatar : MonoBehaviour
{
    public GameObject Male1, Female1, Robot1, Monster;
    GameObject active_object;
    Rigidbody current_body;
    public static string active_character;
    int currentAvatar, soloPosition;
    int[] trials = new int[4] { 1, 2, 3, 4 };
    public static bool  avatar_walking;


    // Start is called before the first frame update
    void Start()
    {
        currentAvatar = 1;
        soloPosition = 0;
        characterReset();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(soloPosition == 4)
            {
                soloPosition = 0;
            }
            soloPosition ++;

            driveCharacterForward();
        }

        currentAvatar = trials[soloPosition];

        if (currentAvatar == 1)
        {
            active_object = Male1;
        }
        else if (currentAvatar == 2)
        {
            active_object = Female1;
        }
        else if (currentAvatar == 3)
        {
            active_object = Robot1;
        }
        else if (currentAvatar == 4)
        {
            active_object = Monster;
        }
    }


    void driveCharacterForward()
    {
        current_body = active_object.GetComponent<Rigidbody>();
        current_body.velocity = ((transform.position * -0.75f) / transform.position.magnitude);
        avatar_walking = true;
    }
    void characterReset()
    {
        active_object.transform.position = new Vector3(-3.5f, active_object.transform.position.y, active_object.transform.position.z);
        current_body.velocity = new Vector3(0f, 0f, 0f);
        //if (Input.GetKeyDown("space"))
        //{
        //    Data_Management.recordData();
        //    Controller_Driver.triggerPressed = false;
        //}
        avatar_walking = false;
    }
}
