using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class cameratest : MonoBehaviour
{
    UnityEngine.Camera cam;
    public GameObject Car = null;
    public float distanceNeededToZoomOut = 0.1f;
    public float defaultZoom = 9.59f;
    public float zoomInSpeed = 1;
    public float zoomOutSpeed = 10;

    void Start()
    {
        cam = UnityEngine.Camera.main;
    }

    private void Awake()
    {
        if (!Car)
        {

        }
    }

    void Update()
    {
        if (Car)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(Car.transform.position);
            if (viewPos.x >= distanceNeededToZoomOut && viewPos.x <= 1 && viewPos.y >= distanceNeededToZoomOut && viewPos.y <= 1 && viewPos.z > 0)
            {
                if(cam.fieldOfView != defaultZoom && !CarController.moving)
                {
                    cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultZoom, zoomInSpeed * Time.deltaTime);
                }
            }
            else
                cam.fieldOfView += zoomOutSpeed * Time.deltaTime;
        }
    }
}
