using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePositionOnAbsoluteAxes : MonoBehaviour
{
    Vector3 initpos;
    public bool fix_X, fix_Y, fix_Z;

    void Start()
    {
        initpos = transform.position;
    }

    void Update()
    {
        if (fix_X)
        {
            transform.position = new Vector3(initpos.x,
                                            transform.position.y,
                                            transform.position.z);
        }

        if (fix_Y)
        {
            transform.position = new Vector3(transform.position.x,
                                             initpos.y,
                                             transform.position.z);
        }

        if (fix_Z)
        {
            transform.position = new Vector3(transform.position.x,
                                            transform.position.y,
                                            initpos.z);
        }
    }
}
