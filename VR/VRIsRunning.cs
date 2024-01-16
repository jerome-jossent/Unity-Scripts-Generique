using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VRIsRunning : MonoBehaviour
{
    public XRLoader WMRLoader;
    public XRLoader MockLoader;

    public XRLoader VR;
    public bool VRisrunning;

    public GameObject[] EnableIfIsRunning;
    public GameObject[] EnableIfIsNOTRunning;
    public GameObject[] DisableIfIsRunning;
    public GameObject[] DisableIfIsNOTRunning;

    void Start()
    {
        VR = XRGeneralSettings.Instance?.Manager?.activeLoader;
        VRisrunning = VR != null;

        if (VRisrunning)
        {
            foreach (GameObject go in EnableIfIsRunning)
                go?.SetActive(true);

            foreach (GameObject go in DisableIfIsRunning)
                go?.SetActive(false);
        }
        else
        {
            foreach (GameObject go in EnableIfIsNOTRunning)
                go?.SetActive(true);

            foreach (GameObject go in DisableIfIsNOTRunning)
                go?.SetActive(false);
        }

        //XRGeneralSettings.Instance.Manager.loaders.Clear();

        ////Initialize WMR.
        //XRGeneralSettings.Instance.Manager.loaders.Add(WMRLoader);
        //XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        //XRGeneralSettings.Instance.Manager.StartSubsystems();

        ////Check if initialization was successfull.
        //var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        //SubsystemManager.GetInstances(xrDisplaySubsystems);
        //bool success = xrDisplaySubsystems[0].running;

        //if (!success)
        //{
        //    //Initialization was not successfull, load mock instead.
        //    print("loading mock");

        //    //Deinitialize WMR
        //    XRGeneralSettings.Instance.Manager.loaders.Clear();
        //    XRGeneralSettings.Instance.Manager.StopSubsystems();
        //    XRGeneralSettings.Instance.Manager.DeinitializeLoader();

        //    //Initialize mock.
        //    XRGeneralSettings.Instance.Manager.loaders.Add(MockLoader);
        //    XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        //    XRGeneralSettings.Instance.Manager.StartSubsystems();
        //}
    }
}
