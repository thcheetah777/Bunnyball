using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangingImage : MonoBehaviour
{

    Image image;

    void Start() {
        image = GetComponent<Image>();
    }

    void Update() {
        image.color = ColorManager.Instance.color;
    }

}
