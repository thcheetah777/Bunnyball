using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{

    public float obstacleBop = 0.5f;
    public float colorSpeed = 0.005f;
    public float cameraBop = 0.2f;
    public bool partying = false;
    public float length = 90;
    private float speed = 0.35f;

    #region Singleton
    
    static public PartyManager Instance = null;
    void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    
    #endregion

    public void StartBonusRound() {
        StartCoroutine(StopParty());
        StartCoroutine(StartParty());
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartBonusRound();
        }
    }

    private IEnumerator StartParty() {
        ColorManager.Instance.changeSpeed = colorSpeed;
        partying = true;

        while (partying)
        {
            yield return new WaitForSeconds(speed);
            foreach (Bop bopper in GameObject.FindObjectsOfType<Bop>())
            {
                if (bopper.gameObject != Camera.main.gameObject)
                {
                    bopper.BopIt(obstacleBop);
                } else
                {
                    bopper.BopIt(cameraBop);
                }
            }
        }
    }

    private IEnumerator StopParty() {
        float colorSpeedBefore = ColorManager.Instance.changeSpeed;
        yield return new WaitForSeconds(length);
        partying = false;
        ColorManager.Instance.changeSpeed = colorSpeedBefore;
    }

}
