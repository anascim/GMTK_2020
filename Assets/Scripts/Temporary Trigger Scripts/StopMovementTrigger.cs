using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovementTrigger : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject == player)
            {
                Debug.LogWarning("The player has lost the ability to Walk");
				player.GetComponent<MagnetInteraction>().canReturnWalk = false;
				player.GetComponent<PlayerController>().canJump = true;
                player.GetComponent<PlayerController>().canWalk = false;
            }
        }
    }
}
