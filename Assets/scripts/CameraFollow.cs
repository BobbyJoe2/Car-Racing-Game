using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed = 5;
    public float cameraOffset = 10;

    public GameObject MainPlayer = null;

    // Start is called before the first frame update
    void Start()
    {
        if (!MainPlayer)
        {
            print("no main player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MainPlayer)
        {
            Vector3 targetposition = new Vector3(MainPlayer.transform.position.x, transform.position.y, MainPlayer.transform.position.z - cameraOffset);

            transform.position = Vector3.Lerp(transform.position, targetposition, speed * Time.deltaTime);
        }
    }
}
