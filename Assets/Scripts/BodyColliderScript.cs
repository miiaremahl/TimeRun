using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyColliderScript : MonoBehaviour
{
    public AudioSource portalAudio;

    public GeneralLogic generalLogic;

    void OnTriggerEnter(Collider other)
    {
        //collides w level object
        if (other.gameObject.CompareTag("TimePortal"))
        {
            portalAudio.Play(0);
        }

        //collides w bonus
        if (other.gameObject.CompareTag("Bonus1"))
        {
            //collect bonus
            generalLogic.CollectBonusPoint(1);

            other.gameObject.GetComponent<BonusPoint>().CollectBonusPoint();
        }
        //collides w bonus
        if (other.gameObject.CompareTag("Bonus2"))
        {
            //collect bonus
            generalLogic.CollectBonusPoint(2);

            other.gameObject.GetComponent<BonusPoint>().CollectBonusPoint();
        }
    }
}
