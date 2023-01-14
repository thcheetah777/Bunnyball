using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowmoManager : MonoBehaviour
{

    public float slowmo = 0.3f;
    public float smoothing = 0.2f;

    private float targetTimeScale = 1;

    #region Singleton
    
    static public SlowmoManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Update() {
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, smoothing);
    }

    public void StartSlowmo() {
        targetTimeScale = slowmo;
        Time.fixedDeltaTime = 0.02f * slowmo;
    }

    public void EndSlowmo() {
        targetTimeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

}
