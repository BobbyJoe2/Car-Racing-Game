using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class Player1Controller : MonoBehaviour
{
    public float speed = 10;
    public float interpSpeed = 2;
    public float rotationSpeed = 1;

    public static bool player1Moving = false;

    Rigidbody rb = null;

    private bool spedUp = false;

    private float speedUpStart = 0;

    public float speedUpLife = 5;

    private float speedUpEnd = 0;

    public float speedUpSpeed = 25;

    public float defaultSpeed = 10;

    public Text speedText;

    public Text positionText;

    public static int placeInRace = 1;

    public static bool finishedRace = false;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player1Moving)
        {
            speedText.text = "0";
        }
        else
        {
            speedText.text = speed.ToString();
        }

        positionText.text = placeInRace.ToString();

        player1Moving = false;

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            player1Moving = true;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            player1Moving = true;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0, rotationSpeed, 0);
            player1Moving = true;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0, -rotationSpeed, 0);
            player1Moving = true;
        }

        if(Time.time >= speedUpEnd)
        {
            spedUp = false;
        }

        if (spedUp)
        {
            speed = Mathf.Lerp(speed, speedUpSpeed, 20 * Time.deltaTime);
        }

        if (!spedUp && speed != defaultSpeed)
        {
            speed = Mathf.Lerp(speed, defaultSpeed, 20 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpeedUp")
        {
            spedUp = true;

            speedUpStart = Time.time;

            speedUpEnd = speedUpStart + speedUpLife;

            Destroy(other.gameObject);
        }
        if(other.tag == ("FinishLine"))
        {
            finishedRace = true;
        }
    }
}