using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 90;
    public int minutes = 0;
    public float seconds = 0;

    TMP_Text timerText;

    #region Singleton
    
    static public Timer Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Start() {
        timerText = GetComponent<TMP_Text>();

        if (ModeManager.Instance.gameMode == GameModes.Classic)
        {
            gameObject.SetActive(false);
        }
    }

    void Update() {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimer();
        } else
        {
            print("Timer Ended");
            Time.timeScale = 0;
            timeRemaining = 0;
            UpdateTimer();
        }
    }

    private void UpdateTimer() {
        minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

}
