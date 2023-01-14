using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float score = 0;
    public TMP_Text scoreText;

    #region Singleton
    
    static public ScoreManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    public void ChangeScore(int scoreIncrement) {
        score += scoreIncrement;
        scoreText.text = score.ToString();
    }

}
