using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float force;
    public bool goingRight;
    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (goingRight)
        {
            tr.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (!goingRight)
        {
            tr.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("asd");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(goingRight ? force : -force, 0f));
        }
    }
}
