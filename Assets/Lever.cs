using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator animator;
    private bool activated = false;

    public void Toggle()
    {
        activated = !activated;
        if (activated)
            animator.SetTrigger("Activate");
        else
            animator.SetTrigger("Deactivate");
    }
}
