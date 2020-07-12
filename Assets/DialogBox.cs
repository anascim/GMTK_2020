using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public static DialogBox shared;
    public Animator animator;
    private Text dialogText;

    private void Awake() {
        if (shared == null)
            shared = this;
    }

    private void Start() {
        dialogText = GetComponentInChildren<Text>();
        dialogText.enabled = false;
    }

    public void AppearWithText(string text)
    {
        animator.SetTrigger("Appear");
        StartCoroutine(ShowText(text));
    }

    private IEnumerator ShowText(string text)
    {
        yield return new WaitForSeconds(0.5f);
        dialogText.text = text;
        dialogText.enabled = true;
        StartCoroutine(Disappear());
    }


    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);
        animator.SetTrigger("Disappear");
        StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(0.3f);
        dialogText.enabled = false;
    }
}
