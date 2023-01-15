using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public ParticleSystem bumpParticle;
    public ParticleSystem wallParticle;
    public float restartDelay = 1;
    public TrailRenderer ballTrail;
    public SpriteRenderer ballRenderer;

    Rigidbody2D ballBody;
    Animator ballAnimator;
    Vector2 startingPosition;
    Shake screenShake;

    void Start() {
        ballBody = GetComponent<Rigidbody2D>();
        ballAnimator = GetComponent<Animator>();
        screenShake = Camera.main.GetComponent<Shake>();

        startingPosition = transform.position;

        StartCoroutine(Reset(false));
    }

    void Update() {
        ballTrail.startColor = ColorManager.Instance.color;
        ballRenderer.color = ColorManager.Instance.color;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.bumper);

            SpawnParticles(bumpParticle);
        } else if (collision.gameObject.CompareTag("Wall")) {
            AudioManager.Instance.PlaySound(AudioManager.Instance.wall);

            SpawnParticles(wallParticle);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.CompareTag("Die"))
        {
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset(bool delay = true) {
        float gravityScaleBefore = ballBody.gravityScale;

        if (delay) yield return new WaitForSeconds(restartDelay);

        ObstacleManager.Instance.GenerateObstacles();
        ballBody.velocity = Vector2.zero;
        if (!ColorManager.Instance.dynamic) ColorManager.Instance.ResetColor();
        transform.position = startingPosition;
        ballTrail.Clear();
        ballBody.gravityScale = 0;
        ballAnimator.SetTrigger("Spawn");

        yield return new WaitForSeconds(1f);

        ballBody.gravityScale = gravityScaleBefore;
    }

    private void Die() {
        SceneLoader.Instance.LoadScene("Game");
    }

    private void SpawnParticles(ParticleSystem particle) {
        Destroy(Instantiate(particle.gameObject, transform.position, Quaternion.identity), 1);
    }

}
