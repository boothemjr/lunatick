using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // THIS LINE OF CODE SHOULD BE USED FOR ANYTHING WE WANT TO BE A SINGLETON
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton
    
    int currentLevel = 1;
    private const int MAX_LEVEL = 1;
    
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

    void Update()
    {
        
    }

    private void AdvanceLevel()
    {
        if (currentLevel >= MAX_LEVEL) // if the level is equal to or greater than the max level, send message and exit
        {
            Debug.Log("WARNING: Can't advance to next level.");
            return;
        }
        currentLevel++; //increase the level number
        SceneManager.LoadScene(currentLevel); //go to the next level
    }
}
