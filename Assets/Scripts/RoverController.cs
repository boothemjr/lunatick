using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    public Rigidbody2D rigidBody; 
    public float thrustVal = 7000f;

    [SerializeField] PhaseManager phaseManager;
    [SerializeField] float phaseSpeedUpRate;

    public WheelJoint2D wheelFront;
    public WheelJoint2D wheelMid;
    public WheelJoint2D wheelRear;
    
    public JointMotor2D motorFront;
    public JointMotor2D motorMid;
    public JointMotor2D motorRear;

    public float speedForward = 7500;
    public float speedBackward = -5;
    
    public float torqueForward = 1;
    public float torqueBackward = -1;

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0) {PhaseAbility();}

        if (Input.GetAxisRaw("Vertical") > 0) // using inputManager for vehicle control - might change later
        {
            // front tire control
            motorFront.motorSpeed = speedForward * -1;
            motorFront.maxMotorTorque = torqueForward;
            wheelFront.motor = motorFront;
            
            // mid tire control
            motorMid.motorSpeed = speedForward * -1;
            motorMid.maxMotorTorque = torqueForward;
            wheelMid.motor = motorMid;
            
            // rear tire control
            motorRear.motorSpeed = speedForward * -1;
            motorRear.maxMotorTorque = torqueForward;
            wheelRear.motor = motorRear;

        }
        
        // move backwards
        else if (Input.GetAxisRaw("Vertical") < 0) 
        {
            // front tire control
            motorFront.motorSpeed = speedBackward * -1;
            motorFront.maxMotorTorque = torqueBackward;
            wheelFront.motor = motorFront;
            
            // mid tire control
            motorMid.motorSpeed = speedBackward * -1;
            motorMid.maxMotorTorque = torqueBackward;
            wheelMid.motor = motorMid;
            
            // rear tire control
            motorRear.motorSpeed = speedBackward * -1;
            motorRear.maxMotorTorque = torqueBackward;
            wheelRear.motor = motorRear;

        }
        
        // do boost when space key pressed
        else if (Input.GetKey(KeyCode.Space)) 
        {
            rigidBody.AddForce(Vector2.up * thrustVal * Time.deltaTime);
        }
        
        // turn off motors if no button pressed
        else
        {
            wheelFront.useMotor = false;
            wheelMid.useMotor = false;
            wheelRear.useMotor = false;
            
        }
    }
    private void PhaseAbility()
    {
         {phaseManager.cycleDay += phaseSpeedUpRate;}
    }
}
