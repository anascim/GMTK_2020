using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetInteraction : MonoBehaviour
{
    //Variables
    public bool hasMagnet;
    public bool isOnArea;
    public float checkRadius;

    //References
    private Rigidbody2D rb;
    public LayerMask whatIsMagnet;
    public Transform magnet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isOnArea = Physics2D.OverlapCircle(magnet.position, checkRadius, whatIsMagnet);

        if (isOnArea && hasMagnet)
        {
            GetComponent<PlayerController>().canWalk = false;
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
        else
        {
            GetComponent<PlayerController>().canWalk = true;
        }
    }
}
