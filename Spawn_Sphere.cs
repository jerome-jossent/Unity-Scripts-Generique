using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Sphere : MonoBehaviour {

    public GameObject spwanobject;
    private int index = 0;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = transform.position;
            Quaternion rotation = spwanobject.transform.rotation;
            GameObject go = Instantiate(spwanobject, pos, rotation);

            go.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            go.name = "Boule n°" + index;
            index++;
        }
    }
}
