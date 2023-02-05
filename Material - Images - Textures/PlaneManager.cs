using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlaneManager : NetworkBehaviour {

    public float speed = 1;
    string filePattern = "Pictures/test_{0:000}";
    public GameObject texturedPlane;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 4; i++)
        {
            GameObject plane = (GameObject)Instantiate(texturedPlane, transform.position, transform.rotation);
            string filename = string.Format(filePattern, i);
            Debug.Log("Loading " + filename);
            Texture2D tex = (Texture2D)Resources.Load(filename);
            plane.GetComponent<PlaneController>().texture = tex;
            NetworkServer.Spawn(plane);
        }
    }
	
	// Update is called once per frame
	void Update () {
        //GameObject plane = (GameObject)Instantiate(texturedPlane, transform.position, transform.rotation);
        
        //NetworkServer.Spawn(plane);
        transform.position = transform.position - new Vector3(0.0f, 0.0f, 0.1f) * speed;
    }
}
