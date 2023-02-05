using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changespeedwhithwheel : MonoBehaviour {

    Animator m_Animator;

    void Start()
    {
        //Get the animator, attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        // Get mouse scrollwheel forwards
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            m_Animator.speed *= 2;
        }

        // Get mouse scrollwheel backwards
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            m_Animator.speed /= 2;
        }
    }
}
