using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bop : MonoBehaviour
{

    private float smoothing = 0.05f;
    private Vector2 originalPosition;

    void Update() {
        transform.position = Vector3.Lerp(transform.position, originalPosition, smoothing);
    }

    public void BopIt(float magnitude) {
        originalPosition = transform.position;
        transform.position += Vector3.up * magnitude;
    }

}
