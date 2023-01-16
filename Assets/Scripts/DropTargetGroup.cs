using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTargetGroup : MonoBehaviour
{

    public void CheckCompleted() {
        bool completed = true;
        foreach (Transform target in transform)
        {
            DropTarget dropTarget = target.GetComponent<DropTarget>();
            if (!dropTarget.activated) completed = false;
        }

        if (completed && LifeManager.Instance.lives != LifeManager.Instance.maxLives)
        {
            LifeManager.Instance.GainLife();
            
            foreach (Transform target in transform)
            {
                DropTarget dropTarget = target.GetComponent<DropTarget>();
                dropTarget.activated = false;
                dropTarget.targetRenderer.color = dropTarget.deactivatedColor;
            }
        }
    }

}
