using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour
{
    private Vector3 rotation;
    public float rotationSpeed = .01f;
    
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(0, rotationSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotation, Space.Self);
    }
}
