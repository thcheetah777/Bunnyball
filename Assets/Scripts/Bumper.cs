using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    public float bumpedSize = 2;
    public float sizeSmoothing = 0.5f;
    public float colorSmoothing = 0.2f;
    public float bounce = 1;
    public int points = 10;

    Vector3 startScale;
    Color startColor;

    void Start() {
        startScale = transform.localScale;
    }

    void Update() {
        transform.localScale = Vector3.Lerp(transform.localScale, startScale, sizeSmoothing);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball"))
        {
            transform.localScale = Vector3.one * bumpedSize;

            Rigidbody2D ballBody = collision.gameObject.GetComponent<Rigidbody2D>();
            ballBody.AddForce(-collision.relativeVelocity.normalized * bounce, ForceMode2D.Impulse);

            ScoreManager.Instance.ChangeScore(points);
        }
    }

}
