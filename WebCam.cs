using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam: MonoBehaviour {

	public GameObject go;

	void Start () {		
		WebCamTexture wct = new WebCamTexture();
		go.GetComponent<Renderer>().material.mainTexture = wct;
		wct.Play();		
	}	
}
