using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //general logic ref
    public GeneralLogic generalLogic;

    //checking for triggers
    void OnTriggerEnter(Collider other)
    {
        //collides w level object
        if (other.gameObject.CompareTag("LevelObject"))
        {
            //lose a life
            generalLogic.LoseLife();
        }
    }



    //controller.inputDevice.sendHapticsimpulse(0,1,time.deltatime);
    //using unity.interaction.toolkit

}
