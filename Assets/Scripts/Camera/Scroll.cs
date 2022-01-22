using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public Animator anim;
    public AudioSource sound;
    public bool is_stopped=false;

    void Start()
    {
    }
    public void DoAnimation()
    {
        sound.Play();
        anim.SetBool("is_need", true);
        is_stopped = false;
    }

    void FixedUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1&&!is_stopped)
        {
            anim.SetBool("is_need", false);
            is_stopped = true;
        }
    }
}
