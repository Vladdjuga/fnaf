using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScreen : MonoBehaviour
{
    public CameraController controller;
    public SideOfCamera side;
    public bool can_slide=true;

    public void OnMouseEnter()
    {
        if(can_slide)
            controller.side = side;
        else
            controller.side = SideOfCamera.NULL;
    }

    public void OnMouseExit()
    {
        controller.side = SideOfCamera.NULL;
    }
    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    Debug.Log("Warn");
    //    if (col.transform.tag == "Wall")
    //    {
    //        can_slide = false;
    //    }
    //}
    //void OnCollisionExit2D(Collision2D col)
    //{
    //    if (col.transform.tag == "Wall")
    //    {
    //        can_slide = true;
    //    }
    //}
}
