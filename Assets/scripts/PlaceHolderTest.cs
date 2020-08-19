using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderTest : MonoBehaviour
{
    private bool player1Passed = false;
    private bool player2Passed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            player1Passed = true;
            if(player2Passed == true)
            {
                Player1Controller.placeInRace = 2;
                Player2Controller.placeInRace = 1;
            }
            if (player2Passed == false)
            {
                Player1Controller.placeInRace = 1;
                Player2Controller.placeInRace = 2;
            }
        }
        if (other.tag == "Player2")
        {
            player2Passed = true;
            if (player1Passed == true)
            {
                Player2Controller.placeInRace = 2;
                Player1Controller.placeInRace = 1;
            }
            if (player1Passed == false)
            {
                Player2Controller.placeInRace = 1;
                Player1Controller.placeInRace = 2;
            }
        }
    }
}