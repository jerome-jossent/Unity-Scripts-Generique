using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactions : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public GameObject spawn;
    public GameObject obj;

    // Use this for initialization
    void Start() {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        Debug.Log(trackedObject.name);

    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPressDown(triggerButton))
        {
            Instantiate(obj, spawn.transform.position, Quaternion.identity);
        }
        
    }
}
