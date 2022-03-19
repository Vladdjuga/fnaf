using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoonUp : MonoBehaviour
{
    public float posYEnd = 0;
    public float speed = 0.1f;
    public GameObject num1;
    public GameObject num2;
    public bool is_end = false;

    public AudioSource bells;
    public AudioSource kids;

    public float timer = 0f;
    public float timerOff = 5.5f;

    void Start()
    {
        posYEnd = num1.transform.position.y;
    }

    void FixedUpdate()
    {
        if (!is_end)
        {
            num1.GetComponent<CharacterController>().Move(new Vector3(0, speed, 0));
            num2.GetComponent<CharacterController>().Move(new Vector3(0, speed, 0));
        }
        if (num2.transform.position.y >= posYEnd&&!is_end)
        {
            num1.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0));
            num2.GetComponent<CharacterController>().Move(new Vector3(0, 0, 0));
            is_end = true;
        }
        if(timer!=0)
            timer += 1 * Time.deltaTime;
        if (timer >= timerOff)
        {
            kids.Play();
            timer = 0;
        }
    }
}
