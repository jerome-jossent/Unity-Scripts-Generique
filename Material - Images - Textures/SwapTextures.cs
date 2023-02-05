using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTextures : MonoBehaviour {
    public Texture[] textures;
    public int currentTexture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            print("kd1");
            currentTexture++;
            currentTexture %= textures.Length;
            gameObject.GetComponent<Renderer>().material.mainTexture = textures[currentTexture];

            print("kd2");
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            currentTexture--;
            if (currentTexture < 0) currentTexture = textures.Length-1;
            gameObject.GetComponent<Renderer>().material.mainTexture = textures[currentTexture];
        }
    }
}
