using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangingParticles : MonoBehaviour
{

    ParticleSystem.MainModule particles;

    void Start() {
        particles = GetComponent<ParticleSystem>().main;
    }

    void Update() {
        particles.startColor = ColorManager.Instance.color; 
    }

}
