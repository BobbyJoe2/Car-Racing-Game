﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Follow : MonoBehaviour
{
    public float speed = 1.42f;
    public float cameraOffset = 15;

    public GameObject MainPlayer = null;

    public UnityEngine.Camera cam;
    public float distanceNeededToZoomOut = 0.1f;
    public float defaultZoom = 60;
    public float zoomInSpeed = 10;
    public float zoomOutSpeed = 15;

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
            Vector3 targetposition = new Vector3(MainPlayer.transform.position.x, MainPlayer.transform.position.y + 10, MainPlayer.transform.position.z - cameraOffset);
            Quaternion targertRotation = Quaternion.Euler(26, MainPlayer.transform.rotation.y, MainPlayer.transform.rotation.z);

            transform.position = Vector3.Lerp(transform.position, targetposition, speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targertRotation, speed * Time.deltaTime);
        }

        /*if (MainPlayer)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(MainPlayer.transform.position);
            if (viewPos.x >= distanceNeededToZoomOut && viewPos.x <= 1 && viewPos.y >= distanceNeededToZoomOut && viewPos.y <= 1 && viewPos.z > 0)
            {
                if (cam.fieldOfView != defaultZoom && !Player1Controller.player1Moving)
                {
                    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultZoom, zoomInSpeed * Time.deltaTime);
                }
            }
            else
                cam.fieldOfView += zoomOutSpeed * Time.deltaTime;
        }*/
    }
}
