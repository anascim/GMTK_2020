using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                DialogBox.shared.AppearWithText("The robot has lost the Jump control!");

                player.GetComponent<PlayerController>().canJump = false;
            }
        }
    }
}
