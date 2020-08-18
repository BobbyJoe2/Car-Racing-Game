using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameObject speedBooster;
    public float speed;
    public float timeWithSpeedBoost = 5;
    private float timeUntilNoSpeedBoost;
    public Player1Controller pc;
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeWithSpeedBoost)
        {
            pc.speed = 20;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("inserthere");
        if (other.gameObject.CompareTag("Player"))
        { pc.speed += 3;
            timeUntilNoSpeedBoost = Time.time + timeWithSpeedBoost;
        }
       
    }
}
