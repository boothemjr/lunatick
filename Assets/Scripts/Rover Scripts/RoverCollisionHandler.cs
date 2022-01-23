using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoverCollisionHandler : MonoBehaviour
{
    [SerializeField] PhaseManager phaseManager;

    // represents status of contact with killzones. 
    // 0 -> no contact. 1 -> in contact with Dark Killzone. 2 -> in contact with Light Killzone
    private int inContactWithZone = 0;


    private void Update() 
    {
        // if in contact with dark killzone & is light, destroy the player
        if (inContactWithZone == 1 && phaseManager.light) {DestroyPlayer();}

        // if in contact with light killzone & is dark, destroy the player
        else if (inContactWithZone == 2 && !phaseManager.light) {DestroyPlayer();}

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("contact");
        // sets status of zone contact
        switch (other.gameObject.tag)
        {
            case "Killzone":
                DestroyPlayer();
                break;
            case "Dark Killzone":
                inContactWithZone = 1;
                break;
            case "Light Killzone":
                inContactWithZone = 2;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        // resets status of zone contact. note that this does not support overlapping zones
        if (other.gameObject.tag == "Killzone") {DestroyPlayer();}
        if (other.gameObject.tag == "Dark Killzone") {inContactWithZone = 0;}
        if (other.gameObject.tag == "Light Killzone") {inContactWithZone = 0;}
    }

    void DestroyPlayer()
    {
        GetComponent<RoverController>().enabled = false;
        Invoke("ReloadLevel", 2f);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
