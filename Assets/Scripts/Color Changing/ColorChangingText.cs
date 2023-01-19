using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColorChangingText : MonoBehaviour
{

    public TMP_Text text;

    void Update() {
        text.color = ColorManager.Instance.color;
    }

}
