using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeDelayScript : MonoBehaviour
{
    public float time = 0f;
    public float speed = 1f;
    public Numbers numbers;
    public SpriteRenderer render;
    public int currentHour=0;
    void Start()
    {
        render.sprite = numbers.s0;
    }

    void FixedUpdate()
    {
        time += speed * Time.deltaTime;

        if (currentHour != Math.Truncate(time))
        {
            currentHour = (int)Math.Truncate(time);
            render.sprite = numbers.getSprite(currentHour);
        }
        if (currentHour == 6)
        {
            //..
            SceneManager.LoadScene("Victory");
        }
    }
}
