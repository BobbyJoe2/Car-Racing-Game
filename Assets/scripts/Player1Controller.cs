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
    public bool hasStar = false;
    private bool spedUp = false;
    private bool spedDown = false;
    private float speedUpStart = 0;
    private float speedDownStart = 0;
    public float speedUpLife = 5;
    
    private float speedUpEnd = 0;
    private float speedDownEnd = 0;
    public float speedUpSpeed = 25;
    public float speedDownSpeed = 10;
    public float defaultSpeed = 10;

    public Text txt;

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
        txt.text = speed.ToString();

        player1Moving = false;
        if (hasStar);
        {
            //make other player stop moving on collision, like Star In Mario Kart
        }
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

        if (Time.time >= speedDownEnd)
        {
            spedDown = false;
        }

        if (spedDown)
        {
            speed = Mathf.Lerp(speed, speedDownSpeed, 20 * Time.deltaTime);
        }

        if (!spedDown && speed != defaultSpeed)
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
        if (other.tag == "SpeedDown")
        {
            spedDown = true;

            speedDownStart = Time.time;

            speedDownEnd = speedDownStart + speedUpLife;

            Destroy(other.gameObject);
            Debug.Log("InsertHere");
        }
    }
}