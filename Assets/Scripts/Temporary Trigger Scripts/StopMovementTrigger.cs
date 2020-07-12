using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopMovementTrigger : MonoBehaviour
{
    private GameObject player;

    private float timer;

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
                timer = 0;
				player.GetComponent<PlayerController>().canReturnWalk = false;
				player.GetComponent<PlayerController>().canJump = true;
                player.GetComponent<PlayerController>().canWalk = false;
                DialogBox.shared.AppearWithText("The robot has lost the Walk control!");
            }
        }
    }
}
