using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DropTargetType
{
    Trigger,
    Collision
}

public class DropTarget : MonoBehaviour
{

    public bool activated = false;
    public Color deactivatedColor = Color.gray;
    public DropTargetType type = DropTargetType.Trigger;
    public SpriteRenderer targetRenderer;

    void Start() {
        targetRenderer.color = deactivatedColor;
    }

    void Update() {
        if (activated)
        {
            targetRenderer.color = ColorManager.Instance.color;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball") && type == DropTargetType.Collision)
        {
            Activate();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.gameObject.CompareTag("Ball") && type == DropTargetType.Trigger)
        {
            Activate();
        }
    }

    private void Activate() {
        activated = true;
        transform.parent.GetComponent<DropTargetGroup>().CheckCompleted();
    }

}
