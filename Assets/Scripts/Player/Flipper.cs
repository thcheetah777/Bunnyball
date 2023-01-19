using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{

    public SpriteRenderer[] flipperRenderer;

    HingeJoint2D hinge;

    void Start() {
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update() {
        foreach (SpriteRenderer renderer in flipperRenderer)
        {
            renderer.color = ColorManager.Instance.color;
        }
    }

    public void Flip() {
        hinge.useMotor = true;
    }

    public void UnFlip() {
        hinge.useMotor = false;
    }

}
