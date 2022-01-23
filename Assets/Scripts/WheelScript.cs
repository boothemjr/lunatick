using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    public bool isTouchingGround;
    
    // Start is called before the first frame update
    void Start()
    {
        isTouchingGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.CompareTag("Floor"))
        {
            isTouchingGround = true;
            //Debug.Log("GROUNDED!");
            RoverManager.instance.SetGrounded(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Floor"))
        {
            isTouchingGround = false;
            //Debug.Log("AIRBORNE!");
            RoverManager.instance.SetGrounded(false);
        }
        
    }

    public bool CheckFloorTouch()
    {
        return isTouchingGround;
    }
}
