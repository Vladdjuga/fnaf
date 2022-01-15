using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCamera : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;
    public CamerasHelper helper;
    public bool is_open=false;
    public GameObject cameras;
    public GameObject controllers;

    void Start()
    {
        animator.enabled = false;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            animator.gameObject.SetActive(false);
            sound.Play();
            is_open = !is_open;
            if (is_open)
            {
                helper.PutOnCamera(cameras, controllers);
            }
        }
    }
    public void OnMouseEnter()
    {
        animator.enabled = true;
        animator.gameObject.SetActive(true);
        if (!is_open)
            animator.SetBool("is_open", true);
        else
        {
            helper.PutOffCamera(cameras, controllers);
            animator.SetBool("is_open_rev", true);
        }

    }
}
