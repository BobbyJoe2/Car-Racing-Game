using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(this.gameObject, lifetime);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
