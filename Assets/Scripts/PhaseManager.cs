using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    // Represents where in the lunar cycle we are in days
    public float cycleDay; 
    public float cycleSpeed = 1f;

    // Lunar cycle is 28 days
    private float cycle = 28;

    // Whether we are in a light or dark cycle
    public bool light;

    // Start is called before the first frame update
    void Start()
    {
        cycleDay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CycleDays();
        DetermineLightOrDark();
    }

    // cycles through the 28 days of the lunar calendar, cycleSpeed of 1 -> 1 day per second
    private void CycleDays()
    {
        if(cycleDay < cycle) {cycleDay += Time.deltaTime * cycleSpeed;}
        else{cycleDay = 0;}
    }

    // calculates if face of moon is light or dark depending on its point in the cycle
    private void DetermineLightOrDark()
    {
        if (cycleDay < 7 || cycleDay > 21) {light = false;}
        else {light = true;} 
    }

}
