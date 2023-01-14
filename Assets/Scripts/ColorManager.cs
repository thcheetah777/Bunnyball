using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public Color defaultColor;
    public float changeSpeed = 0.1f;
    public Color color;
    public bool dynamic = true;
    public bool randomize = true;

    #region Singleton
    
    static public ColorManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Start() {
        if (randomize)
        {
            ResetColor();
        } else
        {
            color = defaultColor;
        }
    }

    void Update() {
        if (dynamic && randomize)
        {
            float h;
            float s;
            float v;

            Color.RGBToHSV(color, out h, out s, out v);

            color = Color.HSVToRGB(Mathf.Clamp01(h + changeSpeed), 1, 1);
        }
    }

    public void ResetColor() {
        color = Color.HSVToRGB(Random.Range(0f, 1f), 1, 1);
    }

}
