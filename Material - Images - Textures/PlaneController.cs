using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlaneController : NetworkBehaviour
{
    //[SyncVar]
    public Texture2D texture;

    //[SyncVar]
    public float speed;

    void Create()
    {
        Texture2DArray textureArray = new Texture2DArray(256, 256, 1, TextureFormat.RGB24, false);
        textureArray.SetPixels(texture.GetPixels(0), 1, 0);
        textureArray.Apply();

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("PlaneManagerObject").transform.position + new Vector3(0.0f, 0.0f, 1.0f);
        //Debug.Log("pos " + GameObject.Find("PlaneManagerObject").transform.position);

    }
}
