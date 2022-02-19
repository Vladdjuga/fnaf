using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animatronic
{
    BONNIE, CHICA,FREDDY,NONE
}
public class Jumpscare : MonoBehaviour
{
    public Animator animator;
    public AudioSource audio;
    public GameObject jump;
    public float duration=1f;
    public float count=0f;
    public bool jumpscare = false;
    public OfficeObject office;
    public bool is_bonnie = false;
    public bool is_chica = false;
    public float durationToJumpscare = 5f;
    public float counterJumpscare = 0f;
    public Animatronic whoCares;
    public GameObject camera;
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
        if (whoCares != Animatronic.NONE)
        {
            if(whoCares == Animatronic.CHICA&&office.door_right|| whoCares == Animatronic.BONNIE && office.door_left)
            {
                if (is_chica && office.door_right && is_bonnie && !office.door_left)
                {
                    whoCares = Animatronic.BONNIE;
                }
                else if (is_chica && !office.door_right && is_bonnie && office.door_left)
                {
                    whoCares = Animatronic.CHICA;
                }
                else
                {
                    counterJumpscare = 0;
                    jumpscare = false;
                }
            }
            else
            {
                counterJumpscare += 1 * Time.deltaTime;
            }
            if (count > 0)
            {
                count += 1 * Time.deltaTime;
            }
            if (count >= duration)
            {
                jumpscare = false;
                audio.Stop();
                whoCares = Animatronic.NONE;
                count = 0f;
                counterJumpscare = 0f;
            }
        }
        //animator.SetBool("is_jumo", is_jumpscare);
        animator.SetBool("is_chica", whoCares == Animatronic.CHICA&& jumpscare==true);
        animator.SetBool("is_jumo", whoCares == Animatronic.BONNIE&& jumpscare==true);

        if (counterJumpscare>0)
            counterJumpscare += 1 * Time.deltaTime;
        if(counterJumpscare >= durationToJumpscare)
        {
            switch (whoCares)
            {
                case Animatronic.BONNIE:
                    jump.SetActive(true);
                    audio.Play();
                    camera.transform.position = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
                    jumpscare = true;
                    counterJumpscare = 0f;
                    break;
                case Animatronic.CHICA:
                    jump.SetActive(true);
                    audio.Play();
                    camera.transform.position = new Vector3(0, camera.transform.position.y, camera.transform.position.z);
                    jumpscare = true;
                    counterJumpscare = 0f;
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
