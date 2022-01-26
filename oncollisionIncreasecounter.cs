using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncollisionIncreasecounter : MonoBehaviour {
    
    private int occurence = 0;
    TextMesh tm;

    private void Start()
    {
        tm = gameObject.GetComponent<TextMesh>();
        touche_Update();
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    occurence++;
    //    touche_Update();
    //}

    private void touche_Update()
    {
        tm.text = occurence.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        occurence++;
        touche_Update();
    }

}
