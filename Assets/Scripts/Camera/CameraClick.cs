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

    void SelectOld()
    {
        this.GetComponent<SpriteRenderer>().sprite = old;
        if(is_audioOnly)
            audioOnly.SetActive(false);
    }

    void Start()
    {
        eventik += SelectOld;
    }

    void Update()
    {
        
    }
    public void OnMouseUp()
    {
        scroll.DoAnimation();
        eventik.Invoke();
        camera.sprite = view;
        text.sprite = roomName;
        this.GetComponent<SpriteRenderer>().sprite = click_button;
        if (is_audioOnly)
            audioOnly.SetActive(true);
    }
}
