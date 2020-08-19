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

    private bool spedUp = false;

    private float speedUpStart = 0;

    public float speedUpLife = 5;

    private float speedUpEnd = 0;

    public float speedUpSpeed = 25;

    public float defaultSpeed = 20;

    public Text speedText;

    public Text positionText;

    public static int placeInRace = 2;

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

        if (Time.time >= speedUpEnd)
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
        if (other.tag == ("FinishLine"))
        {
            finishedRace = true;
        }
    }
}
