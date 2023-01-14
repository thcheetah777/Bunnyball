using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform target;
    public float smoothing = 0.2f;

    public float minY;
    public float maxY;

    public Rigidbody2D ballBody;
    public float velocityMultiplier = 0.2f;

    void Update() {
        Vector3 targetPos = new Vector3(0, Mathf.Clamp(target.position.y + ballBody.velocity.normalized.y * velocityMultiplier, minY, maxY), -10);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }

}
