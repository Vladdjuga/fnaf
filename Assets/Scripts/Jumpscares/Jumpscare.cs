using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public Animator animator;
    public AudioSource audio;
    public GameObject jump;
    public float duration=1f;
    public float count=0f;
    public bool is_jumpscare = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.active = true;
            audio.Play();
            is_jumpscare = true;
        }
        if (is_jumpscare)
        {
            count += 1 * Time.deltaTime;
            if (count >= duration)
            {
                is_jumpscare = false;
                count = 0f;
                audio.Stop();
            }
        }
        animator.SetBool("is_jumo", is_jumpscare);
    }
}
