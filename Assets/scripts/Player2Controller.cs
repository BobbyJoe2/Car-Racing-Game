using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float speed = 20;
    public float interpSpeed = 2;
    public float rotationSpeed = 1;

    public static bool player2Moving = false;

    Rigidbody rb = null;
    public bool hasStar = false;
    public bool canMove = true;

    private bool spedUp = false;
    private bool spedDown = false;
    private float speedUpStart = 0;
    private float speedDownStart = 0;
    public float speedUpLife = 5;
    public float speedFactor = 1;
 
    private float speedUpEnd = 0;
    private float speedDownEnd = 0;
    public float speedUpSpeed = 25;

    public float defaultSpeed = 20;

    public Text speedText;

    public Text positionText;

    public static int placeInRace = 2;

    public static bool finishedRace = false;
    public float speedDownSpeed = 10;
    public float defaultSpeed = 10;

    public Player1Controller pc;
    public float timeFactor = 20;
    public float timeAfterHitByStar = 4;
    public float endOfHitByStar;

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
        if (!player2Moving)
        {
            speedText.text = "0";
        }
        else
        {
            speedText.text = speed.ToString();
        }

        positionText.text = placeInRace.ToString();

        player2Moving = false;

        if (canMove)
        {
            //Movement Code
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                player2Moving = true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                player2Moving = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, rotationSpeed, 0);
                player2Moving = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -rotationSpeed, 0);
                player2Moving = true;
            }
        }
            //speed Up Code
            if (spedUp)
            {
                speed = Mathf.Lerp(speed, speedUpSpeed, timeFactor * Time.deltaTime);
                print("Boost Gained!");
            }

            if (!spedUp && speed != defaultSpeed)
            {
                speed = Mathf.Lerp(speed, defaultSpeed, timeFactor * Time.deltaTime);
            }
            if (Time.time >= speedUpEnd)
            {
                spedUp = false;
            }

            //speed Down Code
            if (spedDown)
            {
                speed = Mathf.Lerp(speed, speedDownSpeed, timeFactor * Time.deltaTime);
            }

            if (!spedDown && speed != defaultSpeed)
            {
                speed = Mathf.Lerp(speed, defaultSpeed, timeFactor * Time.deltaTime);
            }
            if (Time.time >= speedDownEnd)
            {
                spedDown = false;
            }
        
        //Star Code
        if (Time.time >= endOfHitByStar)
        {
            pc.canMove = true;
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
        if (other.tag == ("FinishLine"))
        {
            finishedRace = true;
        }
        if (other.tag == "SpeedDown")
        {
            spedDown = true;

            speedDownStart = Time.time;

            speedDownEnd = speedDownStart + speedUpLife;

            Destroy(other.gameObject);
        }

        if (other.tag == "Star")
        {
            hasStar = true;
            Destroy(other.gameObject);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasStar && collision.gameObject.CompareTag("Player"))
        {
            pc.canMove = false;
            print(collision.gameObject + "hit by star");
            endOfHitByStar = Time.time + timeAfterHitByStar;
        }
    }
}
