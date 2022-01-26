using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Spawn : MonoBehaviour {

    public GameObject spawn;
    public GameObject obj;
    public bool montrucsepasse;

    public void Spawn()
    {
        Instantiate(obj, spawn.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        montrucsepasse = Input.GetMouseButtonDown(0);

        if (montrucsepasse)
        {
            Spawn();
        }

    }
}
