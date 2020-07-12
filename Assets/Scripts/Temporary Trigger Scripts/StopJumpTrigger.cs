using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopJumpTrigger : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject == player)
            {
                Debug.LogWarning("The player has lost the ability to Jump");
                player.GetComponent<PlayerController>().canJump = false;
            }
        }
    }
}
