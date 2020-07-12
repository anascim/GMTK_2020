using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float force;
    public bool goingRight;

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(goingRight ? force : -force, 0f));
        }
    }
}
