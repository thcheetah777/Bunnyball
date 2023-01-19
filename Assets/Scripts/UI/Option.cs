using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{

    public string value = "";
    public float smoothing = 0.2f;
    public Vector2 targetScale;

    void Awake() {
        targetScale = Vector2.one;
    }

    void Update() {
        transform.localScale = Vector2.Lerp(transform.localScale, targetScale, smoothing);
    }

}
