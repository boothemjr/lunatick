using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillzoneCollisionHandler : MonoBehaviour
{
    [SerializeField] PhaseManager phaseManager;
    [SerializeField] bool isLight = true;
    [SerializeField] bool isPureKillZone;
    public RoverManager rover;
    // represents status of contact with killzones. 
    // 0 -> no contact. 1 -> in contact with Dark Killzone. 2 -> in contact with Light Killzone
    private bool inContactWithPlayer = false;
    
    private void Start() 
    {
            phaseManager = GameObject.FindWithTag("Phase Manager").GetComponent<PhaseManager>();
            rover = GameObject.FindWithTag("Rover").GetComponent<RoverManager>();
    }

    private void Update() 
    {
        if (inContactWithPlayer && isPureKillZone) {DestroyPlayer();}
        else if (inContactWithPlayer && isLight != phaseManager.light) {DestroyPlayer();}
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        inContactWithPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        inContactWithPlayer = false;
    }

    void DestroyPlayer()
    {
        rover.StartCrashSequence();
    }

    void ReloadLevel()
    {
        RoverManager.instance.Reset();
    }
}
