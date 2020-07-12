using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTimer : MonoBehaviour
{
    public float changeInterval;
    public PlayerController player;

    private SpriteRenderer sr;

    private float timer;

    [HideInInspector]
    public bool magnetOn;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= changeInterval)
        {
            magnetOn = !magnetOn;
            timer = 0;
        }

        if (magnetOn)
        {
            foreach (BoxCollider2D collider in GetComponents<BoxCollider2D>())
                collider.enabled = true;
            sr.color = new Color32(0, 255, 255, 100);
        }
        if (!magnetOn)
        {
            foreach (BoxCollider2D collider in GetComponents<BoxCollider2D>())
                collider.enabled = false;
            sr.color = new Color32(0, 255, 255, 0);
        }

    }
}
