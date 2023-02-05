using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingModifier : MonoBehaviour
{
    Camera cam;

    public float Val_Init;
    public float Val_Max;
    public float Val_Min;
    public float Val_Step;
    [SerializeField] KeyCode Val_Increase;
    [SerializeField] KeyCode Val_Decrease;
    [SerializeField] KeyCode Val_Reset;

    string value_name = "nearClipPlane";
    float value;

    [SerializeField] float TimeToShow = 2f;
    float TimeToHide;
    float GUI_alpha;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        Val_Init = cam.nearClipPlane;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(Val_Reset))
        { 
            cam.nearClipPlane = Val_Init;
            cam.nearClipPlane = ChangeValue(0); 
        }

        if (Input.GetKey(Val_Increase))
            cam.nearClipPlane = ChangeValue(Val_Step);

        if (Input.GetKey(Val_Decrease))
            cam.nearClipPlane = ChangeValue(-Val_Step);
        
        if (Time.time > TimeToHide && GUI_alpha > 0)
            GUI_alpha -= 0.02f;
    }
    
    float ChangeValue(float val)
    {
        value += val;
        value = Mathf.Clamp(value, Val_Min, Val_Max);
        TimeToHide = Time.time + TimeToShow;
        GUI_alpha = 1;
        return value;
    }
    void OnGUI()
    {
        GUI.color = new Color(1, 1, 1, GUI_alpha);
        GUI.Label(new Rect(10, 10, Screen.width - 10, 20), value_name + " : " + value);
    }
}
