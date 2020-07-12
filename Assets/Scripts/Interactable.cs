using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteraction;
    public UnityEvent OnActivation;
    public UnityEvent OnDeactivation;
    private bool activated = false;

    public void Interact()
    {
        OnInteraction.Invoke();
        activated = !activated;
        if (activated)
            OnActivation.Invoke();
        else
            OnDeactivation.Invoke();
    }
}
