using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{
    public float speed = 10;
    public float interpSpeed = 2;
    public float rotationSpeed = 1;
    public float jumpPower = 20;

    public Transform barrel;

    public static bool moving = false;

    public GameObject bullet = null;

    Rigidbody rb = null;

    public float fireRate = 3;
    private float nextFire = 0;

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
        moving = false;

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            moving = true;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            moving = true;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0, rotationSpeed, 0);
            moving = true;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0, -rotationSpeed, 0);
            moving = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("hello");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (nextFire <= Time.time)
            {
                Instantiate(bullet, barrel);
                nextFire += fireRate;
            }
        }
    }
}