using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnError : MonoBehaviour
{
    public bool is_onError = false;
    public float timeDelay = 0f;
    public float errorTime = 3f;

    public SpriteRenderer spriteRenderer;
    public Color colorNormalNoise;
    public Color colorErrorNoise;
    public AudioSource errorAmbience;
    public OpenCamera openCamera;
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetAudioOnly(bool is_is)
    {
        if (is_is)
            spriteRenderer.color = colorErrorNoise;
        else if (!is_is)
            spriteRenderer.color = colorNormalNoise;
    }

    void FixedUpdate()
    {
        if (openCamera.is_open)
        {
            errorAmbience.mute = false;
        }
        else
        {
            errorAmbience.mute = true;
        }
        if (is_onError)
        {
            timeDelay += 1 * Time.deltaTime;
            is_onError = false;
            spriteRenderer.color = colorErrorNoise;
            if (!errorAmbience.isPlaying)
            {
                errorAmbience.Play();
            }
        }
        if (timeDelay > 0)
        {
            timeDelay += 1 * Time.deltaTime;
            if (timeDelay >= errorTime)
            {
                timeDelay = 0f;
                spriteRenderer.color = colorNormalNoise;
                errorAmbience.Stop();
            }
        }
    }
}
