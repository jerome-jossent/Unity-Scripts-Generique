using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInactiveScriptWithAKey : MonoBehaviour
{
    public MonoBehaviour script;
    public KeyCode KeyCode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode))        
            script.enabled = !script.enabled;

    }
}
