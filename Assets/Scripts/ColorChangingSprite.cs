using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingSprite : MonoBehaviour
{

    public SpriteRenderer[] sprites;

    void Update() {
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = ColorManager.Instance.color;
        }
    }

}
