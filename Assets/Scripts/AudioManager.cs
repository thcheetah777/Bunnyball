using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip bumper;
    public AudioClip wall;

    AudioSource audioSource;

    #region Singleton
    
    static public AudioManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip sound) {
        audioSource.PlayOneShot(sound);
    }

}
