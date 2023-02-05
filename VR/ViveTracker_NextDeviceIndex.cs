using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveTracker_NextDeviceIndex : MonoBehaviour
{
    public Valve.VR.SteamVR_TrackedObject tracker;
    public KeyCode touchePrevious;
    public KeyCode toucheNext;

    private void OnEnable()
    {
        Debug.Log("Vive Tracker : find with " + toucheNext.ToString() + " & " + touchePrevious.ToString());
    }

    void Update()
    {
        if (Input.GetKeyDown(touchePrevious)) _Device_Previous();
        if (Input.GetKeyDown(toucheNext)) _Device_Next();
    }

    public void _Device_Previous()
    {
        int newindex = (int)tracker.index.Previous();
        tracker.SetDeviceIndex(newindex);
    }
    public void _Device_Next()
    {
        int newindex = (int)tracker.index.Next();
        tracker.SetDeviceIndex(newindex);
    }
}
