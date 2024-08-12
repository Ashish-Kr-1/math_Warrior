using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    internal int c = 0;
    void Start()
    {
        
    }

    //private void OnTriggerEnter(Collision collision)
    //{
        //Debug.Log("Collided");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        DM.collided = true;
        this.gameObject.SetActive(false);
    }



}
