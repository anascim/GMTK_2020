using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeColor : MonoBehaviour
{
    public Color colorToChange;
    private Color initialColor;
    private SpriteRenderer sprRenderer;

    private void Start() {
        sprRenderer = GetComponent<SpriteRenderer>();
        initialColor = sprRenderer.color;
    }

    public void Change()
    {
        sprRenderer.color = (sprRenderer.color == initialColor) ? colorToChange : initialColor;
    }
}
