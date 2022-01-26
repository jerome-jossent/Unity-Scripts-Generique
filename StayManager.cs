using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayManager : MonoBehaviour {

    public Camera cam;
    
    // Use this for initialization
    void Start()
    {
        cam.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        cam.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        cam.enabled = false;
    }
}
