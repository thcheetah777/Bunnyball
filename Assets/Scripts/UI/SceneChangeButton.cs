using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeButton : MonoBehaviour, IPointerClickHandler
{

    public string sceneName;

    public void OnPointerClick(PointerEventData eventData) {
        SceneLoader.Instance.LoadScene(sceneName);
    }

}
