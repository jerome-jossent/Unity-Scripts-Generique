using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrthoZoom : MonoBehaviour
{
    public new Camera camera;

    [Range(0.01f, 10f)]
    public float speed;

    [Range(0.01f, 100f)]
    public float zoomMin;
    [Range(0.01f, 100f)]
    public float zoomMax;

    public bool invert;

    void Start()
    {
        if (camera == null)
            camera = Camera.main;
    }

    void Update()
    {
        float val = Input.mouseScrollDelta.y * speed;
        if (val == 0) return;
        if (invert)
            camera.orthographicSize -= val;
        else
            camera.orthographicSize += val;

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, zoomMin, zoomMax);
    }
}
