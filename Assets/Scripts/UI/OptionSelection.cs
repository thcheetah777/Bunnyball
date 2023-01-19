using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OptionSelection : MonoBehaviour
{

    public string playerPrefsID = "";
    [Tooltip("Change the scene based on the option value")] public bool sceneChangeOptions;
    public float scaleChange = 0.2f;
    public UnityEvent onSelect;

    private int index = 0;

    void Start() {
        UpdateChildren();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            UpdateChildren();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index--;
            UpdateChildren();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onSelect.Invoke();
            if (playerPrefsID.Length > 0)
            {
                PlayerPrefs.SetString(playerPrefsID, transform.GetChild(index).GetComponent<Option>().value);
            }
            if (sceneChangeOptions)
            {
                SceneLoader.Instance.LoadScene(transform.GetChild(index).GetComponent<Option>().value);
            }
        }
    }

    private void UpdateChildren() {
        index = (int)Mathf.Clamp(index, 0, transform.childCount - 1);

        foreach (Transform child in transform)
        {
            child.GetComponent<Option>().targetScale = Vector2.one;
        }

        transform.GetChild(index).GetComponent<Option>().targetScale += scaleChange * Vector2.one;
    }

}
