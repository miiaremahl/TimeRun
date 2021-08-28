using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefabEntity : MonoBehaviour
{

    //speed of the prefab entity
    public float speed = 5;

    public bool movementStarted=false;


    void Update()
    {
        if (movementStarted)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }


    public void CallWhenSpawned(float newSpeed)
    {
        SetSpeed(newSpeed);
        movementStarted = true;

    }

    //setting speed
    public void SetSpeed(float newSpeed)
    {
        speed=newSpeed;
    }

    public void DestroyEntity()
    {
        Destroy(gameObject);
    }
}
