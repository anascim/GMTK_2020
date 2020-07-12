using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetJump : MonoBehaviour
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
                DialogBox.shared.AppearWithText("The robot has gain the Jump and Walk controls!");

                player.GetComponent<PlayerController>().canReturnWalk = true;
                player.GetComponent<PlayerController>().canJump = true;
                player.GetComponent<PlayerController>().canWalk = true;
            }
        }
    }
}
