using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToGUI : MonoBehaviour
{
    [SerializeField] PrintToGUI PRINT;
    private void Start()
    {
        PRINT._DisplayText(gameObject.name + "p", transform.position, new Color(1, 0, 0), 20);
        PRINT._DisplayText(gameObject.name + "r", transform.rotation, new Color(1, 1, 0), 20);
    }

    void Update()
    {
        PRINT._DisplayText(gameObject.name + "p", transform.position);
        PRINT._DisplayText(gameObject.name + "r", transform.rotation);
    }
}
