using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public Slider volumeSlider;
    public Toggle fullscreenToggle;
    public AudioMixer audioMixer;

    void Start() {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) > 0 ? true : false;
    }

    public void SetVolume(float value) {
        audioMixer.SetFloat("Volume", value);
        PlayerPrefs.SetFloat("Volume", value);
    }

    public void SetFullscreen(bool value) {
        Screen.fullScreen = value;
        PlayerPrefs.SetInt("Fullscreen", value ? 1 : 0);
    }

}
