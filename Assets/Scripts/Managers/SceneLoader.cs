using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public float delay = 0.5f;

    Animator animator;

    #region Singleton
    
    static public SceneLoader Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Start() {
        animator = GetComponent<Animator>();
    }

    public void LoadScene(string name) {
        StartCoroutine(LoadSceneCoroutine(name));
    }

    private IEnumerator LoadSceneCoroutine(string name) {
        animator.SetTrigger("Out");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name);
        yield return null;
    }

}
