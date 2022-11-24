using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameObjectActiveFromKeyboard : MonoBehaviour
{
    public KeyCode touche;
    public GameObject[] gameObjects;
    bool state;
    public enum StartState { Stay_like_it_is, Enabled, Disabled}
    public StartState start_state;

    private void OnEnable()
    {
        string names = "";

        foreach (var item in gameObjects)
        {
            if (item!= null)
            {
                if (names != "")
                    names += ", ";
                names += item.name;

                if (start_state == StartState.Enabled)
                    item.SetActive(true);

                if (start_state == StartState.Disabled)
                    item.SetActive(false);
            }
        }

        Debug.Log("Active or Inactive " + names + " with " + touche.ToString());
    }

    void Update()
    {
        if (Input.GetKeyDown(touche))
        {
            state = !state;
            foreach (var item in gameObjects)
            {
                if (item != null)
                {
                    item.SetActive(state);
                }
            }
        }
    }
}
