using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BopMode
{
    Size,
    Position
}

public class Bop : MonoBehaviour
{

    public BopMode bopMode = BopMode.Size;
    public bool dynamic = false;
    private float smoothing = 0.02f;
    private Vector2 originalPosition;
    private Vector2 originalScale;

    void Start() {
        originalPosition = transform.position;
        originalScale = transform.localScale;
    }

    void Update() {
        if (dynamic) originalPosition = transform.position;
        if (bopMode == BopMode.Position)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, smoothing);
        } else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, smoothing);
        }
    }

    public void BopIt(float magnitude) {
        if (bopMode == BopMode.Position)
        {
            if (dynamic) originalPosition = transform.position;
            transform.position += Vector3.up * magnitude;
        } else
        {
            transform.localScale += Vector3.one * magnitude;
        }
    }

}
