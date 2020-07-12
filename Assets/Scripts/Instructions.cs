using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogBox.shared.AppearWithText("Press E to interact with levers!");

    }
}
