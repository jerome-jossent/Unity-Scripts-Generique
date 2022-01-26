using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionChangeColour : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
