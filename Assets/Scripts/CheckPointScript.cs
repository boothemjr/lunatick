using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    //private bool respawnSet = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (respawnSet)
        //{
            //respawnSet = false;
            

            //Debug.Log("COLLIDED");
            if (other.GetComponent<Collider2D>().tag == "Player")
            {
                GameObject.FindWithTag("Respawn").tag = "Untagged";
                //Debug.Log("IT'S A PLAYER");
                this.tag = "Respawn";
                RoverManager.instance.RefreshRespawn();
                Debug.Log("Checkpoint updated");
                //respawnSet = true;
            }
        //}
    }
}
