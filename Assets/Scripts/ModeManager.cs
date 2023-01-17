using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameModes
{
    Classic,
    Timed
}

public class ModeManager : MonoBehaviour
{

    public GameModes gameMode;

    #region Singleton
    
    static public ModeManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        switch (PlayerPrefs.GetString("Mode", "Classic"))
        {
            case "Timed": {
                gameMode = GameModes.Timed;
                break;
            }
            default: {
                gameMode = GameModes.Classic;
                break;
            }
        }
    }
    
    #endregion
}
