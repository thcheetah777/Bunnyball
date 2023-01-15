using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float score = 0;
    public TMP_Text scoreText;

    Shake scoreShake;

    #region Singleton
    
    static public ScoreManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion
    
    void Start() {
        scoreShake = scoreText.GetComponent<Shake>();
    }

    void Update() {
        scoreText.color = ColorManager.Instance.color;
    }

    public void ChangeScore(int scoreIncrement) {
        scoreShake.ShakeIt((float)scoreIncrement / 20, (float)scoreIncrement * 1.5f);
        score += scoreIncrement;
        scoreText.text = score.ToString();
    }

}
