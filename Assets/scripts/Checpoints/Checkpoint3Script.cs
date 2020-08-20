using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint3Script : MonoBehaviour
{
    public static bool player1Passed = false;
    public static bool player2Passed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            player1Passed = true;
        }
        if (other.tag == "Player2")
        {
            player2Passed = true;
        }
    }
}