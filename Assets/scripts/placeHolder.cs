using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placeHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Player1Controller.placeInRace == 1 && Player2Controller.placeInRace == 2 && other.tag == "Player2")
        {
            Player1Controller.placeInRace = 2;
            Player2Controller.placeInRace = 1;
        }

        else if (Player1Controller.placeInRace == 2 && Player2Controller.placeInRace == 1 && other.tag == "Player2")
        {
            Player1Controller.placeInRace = 1;
            Player2Controller.placeInRace = 2;
        }
    }
}
