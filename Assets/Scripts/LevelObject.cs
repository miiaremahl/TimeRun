using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{

    //which entity is part of
    public LevelPrefabEntity levelPrefabEntity;

    //checking for triggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DissolveStarter"))
        {
            //add dissolve shader

           // animator.SetTrigger("Fade");
        }

        if (other.gameObject.CompareTag("DissapearingSpot"))
        {
            levelPrefabEntity.DestroyEntity();
        }
    }
}
