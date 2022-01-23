using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody; 
    public float vertThrustVal = 7000f;
    public float horiThrustVal = 3500f;


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
        if (Input.GetAxisRaw("Fire1") > 0) {PhaseAbility();} // activate phase ability

        CheckForGroundMovement();
        CheckForBoost();
        CheckForAirMovement();
        
    }
    private void PhaseAbility()
    {
        phaseManager.cycleDay += phaseSpeedUpRate;
    }

    private void CheckForGroundMovement()
    {
        // move forwards
        if (Input.GetAxisRaw("Vertical") > 0 && RoverManager.instance.grounded) // press D while grounded
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
        else if (Input.GetAxisRaw("Vertical") < 0 && RoverManager.instance.grounded) // press A while grounded
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
        
        // turn off motors if no button pressed
        else
        {
            wheelFront.useMotor = false;
            wheelMid.useMotor = false;
            wheelRear.useMotor = false;
            
        }
    }

    private void CheckForBoost()
    {
        // do boost when space key pressed
        if (Input.GetKey(KeyCode.Space)) 
        {
            rigidBody.AddForce(Vector2.up * vertThrustVal * Time.deltaTime);
            
        }

    }

    private void CheckForAirMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            // move right
            rigidBody.AddForce(Vector2.right * horiThrustVal * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            // move left
            rigidBody.AddForce(Vector2.left * horiThrustVal * Time.deltaTime);
        }
    }

}
