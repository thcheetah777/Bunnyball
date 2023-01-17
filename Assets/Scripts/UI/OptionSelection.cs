using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelection : MonoBehaviour
{

    public string playerPrefsID = "";
    public string sceneChange = "";
    public float scaleChange = 0.2f;
    public bool sceneChangeOptions = false;

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
            PlayerPrefs.SetString(playerPrefsID, transform.GetChild(index).GetComponent<Option>().value);
            print(PlayerPrefs.GetString(playerPrefsID));
            if (sceneChangeOptions)
            {
                SceneLoader.Instance.LoadScene(transform.GetChild(index).GetComponent<Option>().value);
            } else
            {
                SceneLoader.Instance.LoadScene(sceneChange);
            }
        }
    }

    private void UpdateChildren() {
        index = (int)Mathf.Clamp(index, 0, transform.childCount - 1);

        foreach (Transform child in transform)
        {
            child.transform.localScale = Vector3.one;
        }

        transform.GetChild(index).transform.localScale += scaleChange * Vector3.one;
    }

}
