using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCameraWithMouse_InputSystem : MonoBehaviour
{

    public float speedH = 0.2f;
    public float speedV = 0.2f;
    public float panSpeed = 0.4f;

    float yaw = 0.0f;
    float pitch = 0.0f;
    bool isPanning;
    bool keepAltitude;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            isPanning = true;
            keepAltitude = false;
        }

        if (Mouse.current.rightButton.wasReleasedThisFrame)
        {
            isPanning = false;
            keepAltitude = false;
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            isPanning = true;
            keepAltitude = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isPanning = false;
            keepAltitude = true;
        }

        //wheel change altitude
        if (Mouse.current.scroll.IsActuated(0))
        {
            float y = (Mouse.current.scroll.value.y > 0) ? 0.01f : -0.01f;
            transform.Translate(new Vector3(0, y, 0));
        }

    }

    void FixedUpdate()
    {
        //move camera on X & Y
        if (isPanning)
        {
            float h = panSpeed * Mouse.current.delta.y.value;
            float v = panSpeed * Mouse.current.delta.x.value;
            float y = transform.position.y;
            transform.Translate(v, 0, h);
            if (keepAltitude)            
                transform.position = new Vector3(transform.position.x, y, transform.position.z);            
        }
        else
        {
            yaw += speedH * Mouse.current.delta.x.value;
            pitch -= speedV * Mouse.current.delta.y.value;
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
