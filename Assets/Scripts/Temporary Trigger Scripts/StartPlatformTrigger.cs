using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatformTrigger : MonoBehaviour
{
    public GameObject platformTarget;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject == player)
            {
                platformTarget.GetComponent<MovingPlatform>().movementIsActive = true;
            }
        }
    }
}
