using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSimple : MonoBehaviour
{
//https://www.youtube.com/watch?v=hC1QZ0h4oco
//- Boxes that go on the conveyor need a rigidbody and a box collider,
//defaults settings work with no issue
//(so Rigidbody Mass: 1, Drag: 0, Ang Drag: 0.05, UseGravity: yes, IsKinematic: no)
//- Conveyor Belt object needs a rigidbody and a box collider.
//Rigidbody settings: Mass: 1, Drag: 0, Ang Drag:0.05, UseGravity: yes.IsKinematic: YES
//Box collider default settings work fine.Make sure the collider extends
//the length of your conveyor (e.g. if modelling it yourself).

//Also Note, if you have Physics materials on either object's colliders,
//make sure the friction values are greater than 0, and friction combine not set to minimum.

    public float speed;
    Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = rbody.position;

        rbody.position += -transform.right * speed * Time.fixedDeltaTime;

        rbody.MovePosition(pos);

    }
}
