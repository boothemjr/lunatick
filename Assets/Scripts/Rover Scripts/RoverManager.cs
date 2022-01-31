using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverManager : MonoBehaviour
{
    // THIS LINE OF CODE SHOULD BE USED FOR ANYTHING WE WANT TO BE A SINGLETON
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static RoverManager instance; //this static var will hold the Singleton
    private GameObject roverObject;
    private GameObject roverBody;
    public RoverController roverController;
    private GameObject respawn;
    private GameObject frontWheel;
    private GameObject midWheel;
    private GameObject rearWheel;

    private Rigidbody2D roverRB;
    private Rigidbody2D frontWheelRB;
    private Rigidbody2D midWheelRB;
    private Rigidbody2D rearWheelRB;

    private Component frontWheelScript;
    private Component midWheelScript;
    private Component rearWheelScript;

    public bool grounded;
    
    // fields managing death effects
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem explosion;
    
    
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


        roverObject = GameObject.Find("Rover"); // set rover object
        // this doesn't work since roverController is not a part of the object
        //roverController = roverObject.GetComponent<RoverController>();

        roverBody = roverObject.transform.GetChild(0).gameObject; // store rover body
        frontWheel = roverObject.transform.GetChild(1).gameObject; // store front wheel
        midWheel = roverObject.transform.GetChild(2).gameObject; // store mid wheel
        rearWheel = roverObject.transform.GetChild(3).gameObject; // store rear wheel

        frontWheelScript = frontWheel.GetComponent<WheelScript>();
        midWheelScript = midWheel.GetComponent<WheelScript>();
        rearWheelScript = rearWheel.GetComponent<WheelScript>();
        
        RefreshRespawn();
        
        //store rigid bodies
        roverRB = roverBody.GetComponent<Rigidbody2D>();
        frontWheelRB = frontWheel.GetComponent<Rigidbody2D>();
        midWheelRB = midWheel.GetComponent<Rigidbody2D>();
        rearWheelRB = rearWheel.GetComponent<Rigidbody2D>();

        grounded = true;
        
        Reset();
        
        

    }

    private void Update()
    {

    }


    public void Reset()
    {
        
        //set all rigid bodies to zero
        roverRB.velocity = Vector2.zero;
        frontWheelRB.velocity = Vector2.zero;
        frontWheelRB.angularVelocity = 0f;
        midWheelRB.velocity = Vector2.zero;
        midWheelRB.angularVelocity = 0f;
        rearWheelRB.velocity = Vector2.zero;
        rearWheelRB.angularVelocity = 0f;
        
        var newPos = respawn.transform.position;
        
        roverBody.transform.position = newPos; // move rover to respawn position
        newPos += new Vector3(0f, 0f, 1);
        frontWheelRB.transform.position = newPos;
        midWheelRB.transform.position = newPos;
        rearWheelRB.transform.position = newPos;

    }

    public void RefreshRespawn()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
    }

    public void SetGrounded(bool val)
    {
        grounded = val;
    }

    //public method to kill the rover
    public void StartCrashSequence()
    {
        roverController.enabled = false;
        explosion.time = 0;
        explosion.Play();
        Invoke("Reset", loadDelay);
        Invoke("EnableRoverController", loadDelay + 0.1f);
    }

    public void EnableRoverController()
    {
        roverController.enabled = true;
    }

}
