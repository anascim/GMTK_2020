using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTimer : MonoBehaviour
{
    public float changeInterval;

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
            gameObject.layer = 10;
            sr.color = new Color32(0, 255, 255, 100);
        }
        if (!magnetOn)
        {
            gameObject.layer = 0;
            sr.color = new Color32(0, 255, 255, 0);
        }

    }
}
