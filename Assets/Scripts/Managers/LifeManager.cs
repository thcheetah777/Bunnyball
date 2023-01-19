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

    void Start() {
        print(ModeManager.Instance.gameMode);
        if (ModeManager.Instance.gameMode == GameModes.Timed)
        {
            foreach (Image lifeCounter in liveCounters)
            {
                lifeCounter.color = Color.clear;
            }
        }
    }

    void Update() {
        if (ModeManager.Instance.gameMode == GameModes.Classic)
        {
            foreach (Image lifeCounter in liveCounters)
            {
                if (lifeCounter.color != Color.clear)
                {
                    lifeCounter.color = ColorManager.Instance.color;
                }
            }
        }
    }

    public void LoseLife() {
        if (ModeManager.Instance.gameMode == GameModes.Classic)
        {
            lives--;
            liveCounters[lives].color = Color.clear;
            if (lives <= 0)
            {
                print("Lose");
            }
        }
    }

    public void GainLife() {
        if (ModeManager.Instance.gameMode == GameModes.Classic)
        {
            lives++;
            print(lives);
            liveCounters[lives - 1].color = ColorManager.Instance.color;
        }
    }

}
