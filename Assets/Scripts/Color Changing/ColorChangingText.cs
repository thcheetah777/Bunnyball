using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChangingText : MonoBehaviour
{

    TMP_Text text;

    void Start() {
        text = GetComponent<TMP_Text>();
    }

    void Update() {
        text.color = ColorManager.Instance.color;
    }

}
