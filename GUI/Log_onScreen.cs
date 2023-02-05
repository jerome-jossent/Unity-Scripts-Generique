using UnityEngine;
using System.Collections;

public class Log_onScreen : MonoBehaviour
{
    public uint max_messages = 15;  // number of messages to keep
    Queue myLogQueue = new Queue();
    public uint width = 400;
    public int text_size = 20;
    public KeyCode toucheSwitchShow;
    public bool show;

    void Start()
    {
        Debug.Log("Started up logging.");
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void Update()
    {
        if (Input.GetKeyDown(toucheSwitchShow)) 
            show = !show;
    }
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        myLogQueue.Enqueue("[" + type + "] : " + logString);

        if (type == LogType.Exception)
            myLogQueue.Enqueue(stackTrace);

        while (myLogQueue.Count > max_messages)
            myLogQueue.Dequeue();
    }

    void OnGUI()
    {
        if (!show) return;

        GUILayout.BeginArea(new Rect(Screen.width - width, 0, width, Screen.height));
        //GUI.skin.label.fontSize = text_size;

        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = text_size;
        myStyle.wordWrap = true;
        bool unsurdeux = true;
        //GUILayout.Label("\n" + string.Join("\n", myLogQueue.ToArray()));

        foreach (var item in myLogQueue)
        {
            unsurdeux = !unsurdeux;
            myStyle.normal.textColor = (unsurdeux) ? Color.white : new Color(0.8f, 0.8f, 0.8f);
            GUILayout.Label(item.ToString(), myStyle);
        }


        GUILayout.EndArea();
    }
}