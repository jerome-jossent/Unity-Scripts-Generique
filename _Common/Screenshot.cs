using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    string folder;
    //public bool takeScreenshot;
    [Range(1, 10)]
    public int qualityfactor;

    void Start()
    {
        folder = System.IO.Directory.GetCurrentDirectory() + @"\Screenshots\";
        //Debug.Log(folder);
        System.IO.Directory.CreateDirectory(folder);
    }

    public void _TakeScreenshot()
    {
        string filename = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss.fff") + ".png";
        if (!string.IsNullOrEmpty(folder))
            filename = folder + "\\" + filename;
        ScreenCapture.CaptureScreenshot(filename, qualityfactor);
        Debug.Log($"Screenshot to {filename}");
    }

    //private void Update()
    //{
    //    if (takeScreenshot)
    //    {
    //        takeScreenshot = false;
    //        _TakeScreenshot();
    //    }
    //}
}
