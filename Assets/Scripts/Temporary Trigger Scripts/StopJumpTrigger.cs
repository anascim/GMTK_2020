using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopJumpTrigger : MonoBehaviour
{
    private GameObject player;
    public Text alertText;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            alertText.gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject == player)
            {
                timer = 0;
                alertText.text = "The robot has lost the Jump control!";
                alertText.gameObject.SetActive(true);
                player.GetComponent<PlayerController>().canJump = false;
            }
        }
    }
}
