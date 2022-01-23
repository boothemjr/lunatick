using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletonner : MonoBehaviour
{
    public static Singletonner instance; //this static var will hold the Singleton
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
