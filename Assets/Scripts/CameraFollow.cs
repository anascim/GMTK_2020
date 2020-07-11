using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [Range(0f, 1f)] public float lerpAmount;
    public bool onFixedUpdate;

    void Update() 
    {
        if (!onFixedUpdate)
            UpdatePosition();
    }

    void FixedUpdate()
    {
        if (onFixedUpdate)
            UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpAmount);
    }
}
