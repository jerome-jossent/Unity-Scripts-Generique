using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class OuverturePorte : MonoBehaviour
{
    public float rotation_Close;
    public float rotation_Open;
    public float speed;

    public bool open;
    public bool open_previous;

    bool start;

    Quaternion from;
    Quaternion to;

    private void Start()
    {
    }

    Quaternion ComputeQuaternion(float angle)
    {
        Vector3 rotatedForward = Quaternion.Euler(0, angle, 0) * transform.forward;
        Quaternion rotation = Quaternion.LookRotation(rotatedForward, Vector3.up);
        return rotation;
    }

    void Update()
    {
        if (open == open_previous)
            return;

        if (open)
            to = ComputeQuaternion(-rotation_Open);
        else
            to = ComputeQuaternion(rotation_Open);

        transform.rotation = Quaternion.Lerp(transform.rotation, to, speed);

        float angle = Quaternion.Angle(transform.rotation, to);
        Debug.Log(angle);
        if (angle < 1)
        {
            open_previous = open;
        }

    }

    void Animation(Quaternion from, Quaternion to)
    {
        transform.rotation = Quaternion.Lerp(from, to, 1);// Time.time * speed);
    }
}
