using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerleftEvent : MonoBehaviour
{
    public GameObject[] toDisable;
    public AudioSource first;
    public AudioSource circus;
    public SpriteRenderer office;
    public Sprite officeNone;
    public Sprite officeWithFreddy;
    public GameObject freddyJumping;

    public bool is_now=false;
    public float timer = 0f;
    public float timerSec = 5f;
    public float timeToScare = 0f;
    public float whatTime = 10f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        timer += 1 * Time.deltaTime;
        if (timer >= timerSec)
        {
            circus.Play();

        }
    }

    public void Activate()
    {
        for (int i = 0; i < toDisable.Length; i++)
        {
            toDisable[i].SetActive(false);
        }
        first.Play();
        office.sprite = officeNone;
        is_now = true;
    }
}
