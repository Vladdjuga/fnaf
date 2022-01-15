using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClick : MonoBehaviour
{
    public SpriteRenderer camera;
    public Sprite view;
    public Sprite click_button;
    public Sprite old;
    public delegate void ClickHandler();
    public static event ClickHandler eventik;

    void SelectOld()
    {
        this.GetComponent<SpriteRenderer>().sprite = old;
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
        eventik.Invoke();
        camera.sprite = view;
        this.GetComponent<SpriteRenderer>().sprite = click_button;
    }
}
