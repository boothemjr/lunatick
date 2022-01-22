using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverManager : MonoBehaviour
{
    // THIS LINE OF CODE SHOULD BE USED FOR ANYTHING WE WANT TO BE A SINGLETON
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static RoverManager instance; //this static var will hold the Singleton
    private GameObject roverBody;
    private GameObject respawn;
    
    void Start()
    {
        // THIS CODE SHOULD BE USED FOR ANYTHING WE WANT TO BE A SINGLETON
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
            instance = this;  //set instance to this object
        }
        else  //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
        
        roverBody = GameObject.Find("Rover").transform.GetChild(0).gameObject; // store rover body
        respawn = GameObject.FindGameObjectWithTag("Respawn"); // store respawn position
    }

    public void Reset()
    {
        roverBody.transform.position = respawn.transform.position; // move rover to respawn position
    }
}
