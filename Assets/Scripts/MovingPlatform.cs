using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform upperBound;
    public Transform lowerBound;
    public float velocity;
    public bool goingUp;

    void FixedUpdate()
    {
        if (transform.position.y > upperBound.position.y)
            goingUp = false;
        else if (transform.position.y < lowerBound.position.y)
            goingUp = true;

        if (goingUp)
        transform.position = new Vector2(transform.position.x, transform.position.y + velocity * Time.fixedDeltaTime);
        else
            transform.position = new Vector2(transform.position.x, transform.position.y - velocity * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
