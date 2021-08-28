using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
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

        //collides w bonus
        if (other.gameObject.CompareTag("Bonus1"))
        {
            //collect bonus
            generalLogic.CollectBonusPoint(1);

            other.gameObject.GetComponent<BonusPoint>().CollectBonusPoint();
        }

        //collides w bonus2
        if (other.gameObject.CompareTag("Bonus2"))
        {
            //collect bonus
            generalLogic.CollectBonusPoint(2);
            other.gameObject.GetComponent<BonusPoint>().CollectBonusPoint();
        }

        //Restart game
        if (other.gameObject.CompareTag("Restart"))
        {
            generalLogic.ReStart();
        }


    }

}
