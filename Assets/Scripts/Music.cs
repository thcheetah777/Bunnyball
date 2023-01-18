using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    #region Singleton
    
    static public Music Instance = null;
    void Awake() {
        DontDestroyOnLoad(gameObject);
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    #endregion
    
}
