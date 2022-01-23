using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RoverController : MonoBehaviour
{
    
    public Rigidbody2D rigidBody; 
    public float vertThrustVal = 7000f;
    public float horiThrustVal = 1500f;


    [SerializeField] PhaseManager phaseManager;
    [SerializeField] float phaseSpeedUpRate = 1.5f;

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

    public float boostMax = 100f;
    public float boostAmount = 100f;
    public float boostBurnRate = 250f;
    public float boostGainRate = 30f;
    
    public SpriteRenderer spriteRenderer;
    public Sprite lightBody;
    public Sprite darkBody;
    private bool isDarkBody;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0) {UsePhaseAbility(phaseSpeedUpRate * Time.deltaTime);}

        CheckForGroundMovement();
        CheckForBoost();
        CheckForAirMovement();
        if (boostAmount < boostMax && RoverManager.instance.grounded)
        {
            boostAmount = boostMax;
        }
   
        SetSprite(GameManager.instance.isLight);

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
        if (Input.GetKey(KeyCode.Space) && boostAmount > 0f) 
        {
            rigidBody.AddForce(Vector2.up * vertThrustVal * Time.deltaTime);
            boostAmount -= (boostBurnRate * Time.deltaTime);

        }

    }

    private void CheckForAirMovement()
    {
        if (Input.GetKey(KeyCode.D) && /*boostAmount > 0f &&*/ !RoverManager.instance.grounded)
        {
            // move right
            rigidBody.AddForce(Vector2.right * horiThrustVal * Time.deltaTime);
            //boostAmount -= (boostBurnRate * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) && /*boostAmount > 0f &&*/ !RoverManager.instance.grounded)
        {
            // move left
            rigidBody.AddForce(Vector2.left * horiThrustVal * Time.deltaTime);
            //boostAmount -= (boostBurnRate * Time.deltaTime);

        }
    }
    private void UsePhaseAbility(float rate)
    {
        phaseManager.cycleDay += rate;
    }
    
    public void SetSprite(bool status)
    {
        if (status)
        {
            spriteRenderer.sprite = darkBody;
        }
        else
        {
            spriteRenderer.sprite = lightBody;
 
        }
        
    }
    

}
