using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animatronic
{
    BONNIE, CHICA
}
public class Jumpscare : MonoBehaviour
{
    public Animator animator_bonnie;
    public Animator animator_chica;
    public Animator animator_freddy;
    public AudioSource audio;
    public GameObject jump;
    public float duration=1f;
    public float count=0f;
    public bool is_jumpscare = false;
    public OfficeObject office;
    public bool is_bonnie = false;
    public bool is_chica = false;
    public float durationToJumpscare = 5f;
    public float counterJumpscare = 0f;
    public Animatronic whoCares;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jump.active = true;
        //    audio.Play();
        //    is_jumpscare = true;
        //}
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
        animator_bonnie.SetBool("is_jumo", is_jumpscare);
        
        if (counterJumpscare>0)
            counterJumpscare += 1 * Time.deltaTime;
        if(counterJumpscare >= durationToJumpscare)
        {
            switch (whoCares)
            {
                case Animatronic.BONNIE:
                    jump.SetActive(true);
                    audio.Play();
                    is_jumpscare = true;
                    counterJumpscare = 0f;
                    break;
                case Animatronic.CHICA:
                    break;
                default:
                    break;
            }
        }
        if (is_bonnie!= office.is_bonnie)
        {
            is_bonnie = office.is_bonnie;
            counterJumpscare += 1 * Time.deltaTime;
            whoCares = Animatronic.BONNIE;
        }
        if (is_chica != office.is_chica)
        {
            is_chica = office.is_chica;
            counterJumpscare += 1 * Time.deltaTime;
            whoCares = Animatronic.CHICA;
        }
    }
}
