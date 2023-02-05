using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAlpha : MonoBehaviour {

    public GameObject media;
    public float FadeCoefficient = 1.0f;
    public float offset = 0.25f;
    private bool canFade;
    private float alpha;
    private float delta;
    private float originalY;
    private float offsetY;
    private float x;
    private float y;
    private float z;

    // Use this for initialization
    void Start () {
        //renderer.material.SetTexture("_MainTex", texture);
        canFade = false;
        originalY = media.transform.position.y;
        offsetY = originalY - offset;
        x = media.transform.position.x;
        z = media.transform.position.z;

        media.transform.position = new Vector3(x, offsetY, z);
        media.GetComponent<MeshRenderer>().material.color = new Vector4(1,1,1,0);
    }

    public void Update()
    {
        alpha = media.GetComponent<MeshRenderer>().material.color.a;
        delta = FadeCoefficient * Time.deltaTime;
        x = media.transform.position.x;
        y = media.transform.position.y;
        z = media.transform.position.z;
        if (canFade && alpha <= 1) 
        {
            media.GetComponent<MeshRenderer>().material.color += new Color(0, 0, 0, delta);
        }
        if (!canFade && alpha >= 0)
        {
            media.GetComponent<MeshRenderer>().material.color -= new Color(0, 0, 0, delta);
        }

        media.transform.position = new Vector3(x, offsetY + alpha * offset, z);

        //  Debug.Log(y);   
    }

    private void OnTriggerEnter(Collider other)
    {
        //return;
        //if (other.tag == "Player") 
            canFade = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //return;
        //if (other.tag == "Player")
            canFade = false;
    }
}
