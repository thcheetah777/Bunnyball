using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{

    public float force = 10;

    Rigidbody2D playerBody;

    void Start() {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SlowmoManager.Instance.StartSlowmo();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SlowmoManager.Instance.EndSlowmo();

            playerBody.AddForce(playerBody.velocity.normalized * force, ForceMode2D.Impulse);
        }
    }

}
