using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraWithMouse : MonoBehaviour {
 	
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public float panSpeed = 4.0f;
	
    float horizontalSpeed = 1;//0.400f;
    float verticalSpeed = 1;//0.400f;
    float yaw = 0.0f;
    float pitch = 0.0f;		
    bool isPanning;

    void Update ()
    {

        if (Input.GetMouseButtonDown(1)) // 1: clik droit          
            isPanning = true;        

        if (Input.GetMouseButtonUp(1)) 
			isPanning = false;

        //move camera on X & Y
        if (isPanning)
        {			
            float h = horizontalSpeed * Input.GetAxis("Mouse Y");
            float v = verticalSpeed * Input.GetAxis("Mouse X");

            transform.Translate(v, 0, h);
        }
        else
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
