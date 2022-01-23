using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillzoneCollisionHandler : MonoBehaviour
{
    [SerializeField] PhaseManager phaseManager;
    [SerializeField] bool isLight = true;
    [SerializeField] bool isPureKillZone;
    // represents status of contact with killzones. 
    // 0 -> no contact. 1 -> in contact with Dark Killzone. 2 -> in contact with Light Killzone
    private bool inContactWithPlayer = false;
    


    private void Update() 
    {
        Debug.Log(inContactWithPlayer);
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
        Invoke("ReloadLevel", 2f);
    }

    void ReloadLevel()
    {
        RoverManager.instance.Reset();
    }
}
