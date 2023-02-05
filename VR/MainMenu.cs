using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    static bool vrEnabled;

    public void OnValueChanged(int i)
    {
        if (i > 0)
        {
            PlayerPrefs.SetInt("GAME MODE", i-1);
            Debug.Log("GAME MODE " + (i - 1) + " saved !");
            SceneManager.LoadScene(1);
        } 
    }


    public void PlayVR()
    {
        vrEnabled = true;
        SceneManager.LoadScene(1);
    }

    public void PlayPC()
    {
        vrEnabled = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
