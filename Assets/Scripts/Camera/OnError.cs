using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnError : MonoBehaviour
{
    public bool is_onError=false;
    public float timeDelay = 0f;
    public float errorTime = 3f;

    public SpriteRenderer spriteRenderer;
    public Color colorNormalNoise;
    public Color colorErrorNoise;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (is_onError)
        {
            timeDelay += 1 * Time.deltaTime;
            is_onError = false;
            spriteRenderer.color = colorErrorNoise;
        }
        if (timeDelay > 0)
        {
            timeDelay += 1 * Time.deltaTime;
            if (timeDelay >= errorTime)
            {
                timeDelay = 0f;
                spriteRenderer.color = colorNormalNoise;
            }
        }
    }
}
