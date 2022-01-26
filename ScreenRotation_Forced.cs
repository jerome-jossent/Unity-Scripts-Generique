using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRotation_Forced : MonoBehaviour
{
    [SerializeField] ScreenOrientation screenOrientation;

    void Start()
    {
        Screen.orientation = screenOrientation;
    }
}
