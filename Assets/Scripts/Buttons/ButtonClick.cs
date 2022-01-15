using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public Sprite default_sprite;
    public Sprite clicked_light;
    public Sprite clicked_door;
    public Sprite clicked_light_door;
    public SpriteRenderer office;
    public SpriteRenderer buttons;
    public Sprite office_def;
    public Sprite office_1;
    public bool is_door;
    public Animator door;
    public OfficeObject officeObject;
    public AudioSource doorAudio;

    public bool is_lightON = false;
    public bool is_left = true;

    public float time_door=0;
    public float door_dur=1f;
    public bool is_doorClicked=false;

    void Start()
    {

    }
    void Update()
    {
        if (is_lightON)
        {
            float chn = Random.Range(0, 100);
            if (chn <= 5f)
                office.sprite = office_def;
            else
                office.sprite = office_1;
        }

        if (time_door < door_dur && is_doorClicked)
        {
            time_door += Time.deltaTime * 1;
        }
        else if (time_door >= door_dur && is_doorClicked)
        {
            time_door = 0;
            is_doorClicked = false;
        }
    }
    public void OnMouseDown()
    {
        if (!is_door)
        {
            if (is_left)
            {
                if (officeObject.door_left)
                    buttons.sprite = clicked_light_door;
                else
                    buttons.sprite = clicked_light;
            }
            else
            {
                if (officeObject.door_right)
                    buttons.sprite = clicked_light_door;
                else
                    buttons.sprite = clicked_light;
            }
            office.sprite = office_1;
            is_lightON = true;
            if (is_left)
                officeObject.light_left = true;
            else
                officeObject.light_right = true;
        }
    }
    public void OnMouseUp()
    {
        if (!is_door)
        {
            office.sprite = office_def;
            is_lightON = false;
            if (is_left)
            {
                if (officeObject.door_left)
                    buttons.sprite = clicked_door;
                else
                    buttons.sprite = default_sprite;
                officeObject.light_left = false;
            }
            else
            {
                if (officeObject.door_right)
                    buttons.sprite = clicked_door;
                else
                    buttons.sprite = default_sprite;
                officeObject.light_right = false;
            }
        }
        if (is_door)
        {
            if (time_door == 0)
            {
                doorAudio.Play();
                door.SetBool("is_closed", !door.GetBool("is_closed"));

                if (is_left)
                {
                    if (officeObject.light_left)
                    {
                        if (door.GetBool("is_closed"))
                            buttons.sprite = clicked_light_door;
                        else
                            buttons.sprite = clicked_light;
                    }
                    else
                    {
                        if (door.GetBool("is_closed"))
                            buttons.sprite = clicked_door;
                        else
                            buttons.sprite = default_sprite;
                    }
                    officeObject.door_left = door.GetBool("is_closed");
                }
                else
                {
                    if (officeObject.light_right)
                    {
                        if (door.GetBool("is_closed"))
                            buttons.sprite = clicked_light_door;
                        else
                            buttons.sprite = clicked_light;
                    }
                    else
                    {
                        if (door.GetBool("is_closed"))
                            buttons.sprite = clicked_door;
                        else
                            buttons.sprite = default_sprite;
                    }
                    officeObject.door_right = door.GetBool("is_closed");
                }
                is_doorClicked = true;
            }
        }
    }
}
