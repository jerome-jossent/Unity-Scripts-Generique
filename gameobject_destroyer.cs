using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameobject_destroyer : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
