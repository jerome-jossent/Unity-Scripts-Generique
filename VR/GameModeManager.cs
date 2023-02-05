using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{

    public GameObject PCPlayer;
    public GameObject VRPlayer;
    //https://docs.unity3d.com/Manual/OpenVRControllers.html
    public bool defaultIsVR;
    static int gameMode;

    // Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.HasKey("GAME MODE"))
        {
            gameMode = PlayerPrefs.GetInt("GAME MODE");
            Debug.Log("Game mode : " + gameMode);

            switch (gameMode)
            {
                case 0:
                    PCPlayer.SetActive(false);
                    VRPlayer.SetActive(true);
                    break;

                case 1:
                    VRPlayer.SetActive(false);
                    PCPlayer.SetActive(true);
                    break;

                default:
                    if (defaultIsVR == true)
                    {
                        VRPlayer.SetActive(true);
                        PCPlayer.SetActive(false);
                    }
                    else
                    {
                        VRPlayer.SetActive(false);
                        PCPlayer.SetActive(true);
                    }
                    break;
            }
        }
        else Debug.Log("Game mode not found");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
