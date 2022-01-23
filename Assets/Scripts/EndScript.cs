using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("COLLIDED");
        if (other.GetComponent<Collider2D>().tag == "Player")
        {
            //Debug.Log("IT'S A PLAYER");
            GameManager.instance.AdvanceLevel();
        }
    }

}
