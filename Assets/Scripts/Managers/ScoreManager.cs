using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public float score = 0;
    public float indicatorDestroyDelay = 1;
    public TMP_Text scoreText;
    public TMP_Text scoreIndicator;
    public Transform canvasTransform;

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

    public void ChangeScore(int scoreIncrement, Vector2 hitPos) {
        scoreShake.ShakeIt((float)scoreIncrement / 200, (float)scoreIncrement * 0.15f);
        score += scoreIncrement;
        scoreText.text = score.ToString();

        if (hitPos != null)
        {
            GameObject indicator = Instantiate(scoreIndicator.gameObject, hitPos, Quaternion.identity, canvasTransform);
            Destroy(indicator, indicatorDestroyDelay);
            TMP_Text indicatorText = indicator.GetComponent<TMP_Text>();
            indicatorText.color = ColorManager.Instance.color;
            indicatorText.text = "+" + scoreIncrement;
        }
    }

}
