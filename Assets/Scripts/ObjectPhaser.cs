using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhaser : MonoBehaviour
{
    private BoxCollider2D myBody;
    public PhaseManager phaseManager;
    
    public bool isLight = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<BoxCollider2D>() as BoxCollider2D; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isLight == phaseManager.light){myBody.enabled = true;}
        else if (isLight != phaseManager.light){myBody.enabled = false;}
    }

}
