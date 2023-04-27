using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    int cameraIndexWanted;
    int cameraIndexCurrent;
    public KeyCode key_nextCamera;
    public KeyCode key_previousCamera;

    void Start()
    {
        cameraIndexWanted = 0;
        cameraIndexCurrent = 0;
        //Turn all cameras off, except the first default one
        for (int i = 0; i < cameras.Length; i++)
            if (i == 0)
                cameras[i].gameObject.SetActive(true);
            else
                cameras[i].gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(key_nextCamera))
        {
            cameraIndexWanted++;
            ChangeCamera();
        }
        if (Input.GetKeyDown(key_previousCamera))
        {
            cameraIndexWanted--;
            ChangeCamera();
        }
    }

    void ChangeCamera()
    {
        //test de dépassement de capacité de la liste par rapport à l'index souhaité
        if (cameraIndexWanted < 0) cameraIndexWanted = cameras.Length - 1;
        if (cameraIndexWanted > cameras.Length - 1) cameraIndexWanted = 0;

        cameras[cameraIndexCurrent].gameObject.SetActive(false);
        cameras[cameraIndexWanted].gameObject.SetActive(true);
        cameraIndexCurrent = cameraIndexWanted;
    }
}