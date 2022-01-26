using UnityEngine;

public class Menu : MonoBehaviour {
    public float TimeScale = 1.0f;
    private bool isPaused;

    private void Start()
    {
        Time.timeScale = TimeScale;
    }



    void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isPaused = !isPaused;

            if (!isPaused)
                Time.timeScale = TimeScale;
            else
            {
                Application.Quit();
                Time.timeScale = 0f; //met en pause dans le cas du debug            
            }
        }
    }    
}