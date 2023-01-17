using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public float speed = 0.5f;

    #region Singleton
    
    static public Music Instance = null;
    void Awake() {
        DontDestroyOnLoad(gameObject);
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    #endregion
    
    void Start() {
        StartCoroutine(Thing());
    }

    private IEnumerator Thing() {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            Camera.main.GetComponent<Bop>().BopIt(0.2f);
        }
    }

}
