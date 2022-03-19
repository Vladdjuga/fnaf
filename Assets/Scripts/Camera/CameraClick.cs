using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Scroll;

public class CameraClick : MonoBehaviour
{
    public SpriteRenderer camera;
    public Sprite view;
    public Sprite click_button;
    public Sprite old;
    public delegate void ClickHandler();
    public static event ClickHandler eventik;
    public Scroll scroll;
    public Sprite roomName;
    public SpriteRenderer text;
    public bool is_audioOnly;
    public GameObject audioOnly;
    public CameraAnima cameraObject;
    public bool is_spying=false;
    [Header("Home camera attributes")]
    public bool is_HOMECAM;
    public bool is_bonnie;
    public bool is_chica;
    public bool is_freddy;
    public CAM1AExpert expert;
    [Header("Errors")]
    public OnError onError;
    void SelectOld()
    {
        this.GetComponent<SpriteRenderer>().sprite = old;
        if (is_audioOnly)
        {
            audioOnly.SetActive(false);
            //onError.SetAudioOnly(false);
        }
        is_spying = false;
    }

    void Start()
    {
        eventik += SelectOld;
    }
    private void Awake()
    {
        if (cameraObject != null)
            cameraObject.is_animatronic = false;
    }
    void Update()
    {

    }
    public void UpdateCam()
    {
        this.view = expert.getSprite(is_bonnie, is_chica, is_freddy);
        Changed();
    }
    public void Changed()
    {
        if(is_spying)
            camera.sprite = view;
    }
    public void OnMouseUp()
    {
        scroll.DoAnimation();
        scroll.GetComponent<SpriteRenderer>().sprite=null;
        eventik.Invoke();
        camera.sprite = view;
        text.sprite = roomName;
        this.GetComponent<SpriteRenderer>().sprite = click_button;
        if (is_audioOnly)
        {
            audioOnly.SetActive(true);
            //onError.SetAudioOnly(true);
        }
        is_spying = true;
    }
}
