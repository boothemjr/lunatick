using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    // Represents where in the lunar cycle we are in days
    public float cycleDay; 

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

    private void CycleDays()
    {
        if(cycleDay < 28) {cycleDay += Time.deltaTime;}
        else{cycleDay = 0;}
    }

    private void DetermineLightOrDark()
    {
        if (cycleDay < 7 || cycleDay > 21) {light = false;}
        else {light = true;} 
    }
}
