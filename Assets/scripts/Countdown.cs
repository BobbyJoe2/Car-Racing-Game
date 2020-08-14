using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float delay = 1;
    private float runTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= runTime && Time.time < 10){
            print(10 - runTime);
            runTime += delay;
        }
        else if(Time.time >= 10 && Time.time < 11){
            print("countdown finished!");
        }
        else{

        }
    }
}
