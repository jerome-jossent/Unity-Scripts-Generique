﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOfGameObjectAtStart : MonoBehaviour
{
    [SerializeField] GameObject[] EnableAtStart;
    [SerializeField] GameObject[] DisableAtStart;
    [SerializeField] GameObject[] DeleteAtStart;
    void Start()
    {
        foreach (GameObject item in EnableAtStart)
            item?.SetActive(true);

        foreach (GameObject item in DisableAtStart)
            item?.SetActive(false);

        foreach (GameObject item in DeleteAtStart)
            if(item != null)
                DestroyImmediate(item);
    }

}
