using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool movementIsActive;

    public Transform upperBound;
    public Transform lowerBound;
    public Transform platform;
    public float velocity;
    public bool goingUp;

    private Transform target;
    private Transform other {
        get {
            if (target == upperBound)
                return lowerBound;
            else
                return upperBound;
        }
    }
    private Vector2 direction;

    void Start() {
        if (goingUp)
        {
            target = upperBound;
        }
        else
        {
            target = lowerBound;
        }
    }

    void FixedUpdate()
    {
        if (movementIsActive)
        {
            // check if passed through target
            if (Vector2.Dot(target.position - platform.position, other.position - platform.position) > -0.1f)
            {
                target = other;
                goingUp = !goingUp;
            }
            direction = (target.position - platform.position).normalized;
            platform.position = new Vector2(platform.position.x + direction.x * velocity * Time.fixedDeltaTime,
                                             platform.position.y + direction.y * velocity * Time.fixedDeltaTime);
        }
    }
}