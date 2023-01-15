using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashing : MonoBehaviour
{

    public float force = 10;
    public float angleChangeSpeed = 1;

    public float angle = 0;

    Rigidbody2D playerBody;

    void Start() {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SlowmoManager.Instance.StartSlowmo();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                angle -= angleChangeSpeed;
            } else if (Input.GetKey(KeyCode.LeftArrow))
            {
                angle += angleChangeSpeed;
            }

            Debug.DrawRay(transform.position, Quaternion.Euler(0, 0, angle) * Vector2.right, Color.cyan, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SlowmoManager.Instance.EndSlowmo();

            playerBody.velocity = Vector2.zero;
            playerBody.AddForce(Quaternion.Euler(0, 0, angle) * Vector2.right * force, ForceMode2D.Impulse);
        }
    }

}
