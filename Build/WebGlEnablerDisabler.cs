using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebGlEnablerDisabler : MonoBehaviour
{
    public GameObject[] GO_to_disable;
    public GameObject[] GO_to_enable;

    void Awake()
    {
#if UNITY_WEBGL
        Disable();
        Enabled();
#endif
    }

    void Disable()
    {
        foreach (GameObject go in GO_to_disable)
            go?.SetActive(false);
    }
    
    void Enabled()
    {
        foreach (GameObject go in GO_to_enable)
            go?.SetActive(true);
    }
}
