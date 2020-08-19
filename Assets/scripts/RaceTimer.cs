using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RaceTimer : MonoBehaviour
{
    private float currentTime = 0;
    public Text timertext;
    public bool RaceFinished;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(RaceFinished == false)
        {
            currentTime = currentTime + Time.deltaTime;
            if (timertext != null)
            {
                timertext.text = Mathf.Round(currentTime).ToString();
            }
        }

    //    Debug.Log(currentTime);
    }
}
