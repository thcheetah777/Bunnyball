using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{

    HingeJoint2D hinge;

    void Start() {
        hinge = GetComponent<HingeJoint2D>();
    }

    public void Flip() {
        hinge.useMotor = true;
    }

    public void UnFlip() {
        hinge.useMotor = false;
    }

}
