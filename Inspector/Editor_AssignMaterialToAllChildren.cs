using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[ExecuteInEditMode]
public class Editor_AssignMaterialToAllChildren : MonoBehaviour
{
    public bool GO;
    public Material material_to_apply;

    int count;
    void OnValidate()
    {
        if (GO)
        {
            count = 0;
            Debug.Log("Start");
            APPLY(gameObject);
            GO = false;
            Debug.Log("End : " + count);
        }
    }

    private void APPLY(GameObject go)
    {
        //lui-même
        Renderer renderer = go.GetComponent<Renderer>();
        if (renderer != null)
        {
            Material[] materials = go.GetComponent<Renderer>().sharedMaterials;
            for (int i = 0; i < materials.Length; i++)
                materials[i] = material_to_apply;
            go.GetComponent<Renderer>().sharedMaterials = materials;
            count++;
        }

        //ses enfants
        for (int i = 0; i < go.transform.childCount; i++)
            APPLY(go.transform.GetChild(i).gameObject);
    }
}
