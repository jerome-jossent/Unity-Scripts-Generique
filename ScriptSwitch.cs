using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSwitch : MonoBehaviour
{
    public KeyCode touche;

    public MonoBehaviour[] scripts;
    bool state;
    public enum StartState { Stay_like_it_is, Enabled, Disabled }
    public StartState start_state;

    private void OnEnable()
    {
        string names = "";

        foreach (var item in scripts)
        {
            if (item != null)
            {
                if (names != "")
                    names += ", ";
                names += item.name;

                if (start_state == StartState.Enabled)
                    item.enabled = true;

                if (start_state == StartState.Disabled)
                    item.enabled = false;
            }
        }

        Debug.Log("Active or Inactive " + names + " with " + touche.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(touche))
        {
            foreach (var item in scripts)
            {
                if (item != null)
                {
                    item.enabled = !item.enabled;
                }
            }
        }
    }
}
