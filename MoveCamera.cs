using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCamera : MonoBehaviour {
    //rotation
    public float speedYaw = 2.0f;
    public float speedPitch = 2.0f;

    private float yaw;
    private float pitch;

    //translation
    public float speedXY = 0.5f;
    public float speedZ = 5f;

    private float X;
    private float Y;
    private float Z;

    public Text text;

    private bool _debug = false;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //set with actual orientation of camera
        yaw = transform.rotation.eulerAngles.y;
        pitch = transform.rotation.eulerAngles.x;
    }

    void Update()
    {
        if (_debug && text !=null)
        {             
            string debug = "";
            debug += "Mouse X : " + Input.GetAxis("Mouse X") + "\n";
            debug += "Mouse Y : " + Input.GetAxis("Mouse Y") + "\n";
            debug += "Vertical : " + Input.GetAxis("Vertical") + "\n";
            debug += "Horizontal : " + Input.GetAxis("Horizontal") + "\n";
            debug += "ScrollWheel : " + Input.GetAxis("Mouse ScrollWheel");

            text.text = debug;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _debug = !_debug;
            text.enabled = _debug;
        }

        //rotation
        yaw += speedYaw * Input.GetAxis("Mouse X");
        pitch -= speedPitch * Input.GetAxis("Mouse Y");

        //translation
        Y = speedXY * Input.GetAxis("Vertical");
        X = speedXY * Input.GetAxis("Horizontal");
        Z = speedZ * Input.GetAxis("Mouse ScrollWheel");
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        transform.Translate(new Vector3(X, Z, Y));        
    }    
}
