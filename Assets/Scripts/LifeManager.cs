using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LifeManager : MonoBehaviour
{

    public int lives = 5;
    public int maxLives = 5;

    public Image[] liveCounters;

    #region Singleton
    
    static public LifeManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Update() {
        foreach (Image lifeCounter in liveCounters)
        {
            lifeCounter.color = ColorManager.Instance.color;
        }
    }

    public void LoseLife() {
        lives--;
        Destroy(liveCounters[liveCounters.Length - 1]);
        liveCounters = liveCounters.SkipLast(1).ToArray();
        if (lives <= 0)
        {
            print("Lose");
        }
    }

}
