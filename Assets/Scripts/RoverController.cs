using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{

    public WheelJoint2D wheelFront;
    public WheelJoint2D wheelMid;
    public WheelJoint2D wheelRear;
    
    public JointMotor2D motorFront;
    public JointMotor2D motorMid;
    public JointMotor2D motorRear;

    public float speedForward;
    public float speedBackward;
    
    public float torqueForward;
    public float torqueBackward;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0) // using inputManager for vehicle control - might change later
        {
            motorFront.motorSpeed = speedForward * -1;
            motorFront.maxMotorTorque = torqueForward;
            wheelFront.motor = motorFront;
            
            motorMid.motorSpeed = speedForward * -1;
            motorMid.maxMotorTorque = torqueForward;
            wheelMid.motor = motorMid;
            
            motorRear.motorSpeed = speedForward * -1;
            motorRear.maxMotorTorque = torqueForward;
            wheelRear.motor = motorRear;

        }
        
        else if (Input.GetAxisRaw("Vertical") < 0) 
        {
            motorFront.motorSpeed = speedBackward * -1;
            motorFront.maxMotorTorque = torqueBackward;
            wheelFront.motor = motorFront;
            
            motorMid.motorSpeed = speedBackward * -1;
            motorMid.maxMotorTorque = torqueBackward;
            wheelMid.motor = motorMid;
            
            motorRear.motorSpeed = speedBackward * -1;
            motorRear.maxMotorTorque = torqueBackward;
            wheelRear.motor = motorRear;

        }
        else
        {
            wheelFront.useMotor = false;
            wheelMid.useMotor = false;
            wheelRear.useMotor = false;
            
        }
    }
}
