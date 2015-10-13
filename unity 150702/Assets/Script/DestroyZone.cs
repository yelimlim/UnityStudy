﻿using UnityEngine;
using System.Collections;

public class DestroyZone : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Object :" + other.gameObject.name);
        if(other.gameObject.name.Contains("player"))
        {
            other.transform.position = new Vector3(0.0f, 100.0f, 0.0f);
        }
        else if(other.gameObject.name.Contains("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}
