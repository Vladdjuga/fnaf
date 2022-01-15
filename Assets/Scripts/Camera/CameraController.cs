using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SideOfCamera
{
    NULL=0,LEFT=-1,RIGHT=1
}
public class CameraController : MonoBehaviour
{
    public SideOfCamera side;
    public CharacterController controller;
    public float speed=5f;
    public Vector2 vector=Vector2.zero;
    public float leftLim = 0f;
    public float rightLim = 0f;
    public bool is_cameraMode = false;
    public SideOfCamera sideCameraMode= SideOfCamera.LEFT;
    public float cameraModeSpeed= 2f;
    public float durationAcc = 1f;
    public float stop = 0f;
    public CamerasHelper helper;

    void Start()
    {
        helper.eventik += ChangeCameraMode;
        controller = GetComponent<CharacterController>();
        side = SideOfCamera.NULL;
    }
    void ChangeCameraMode(bool mode)
    {
        is_cameraMode = mode;
    }

    void FixedUpdate()
    {
        if (!is_cameraMode)
        {
            if (side != SideOfCamera.NULL)
            {
                vector = new Vector3((int)side * speed, 0, 0);
                controller.Move(vector);
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, leftLim, rightLim), transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (stop != 0f)
            {
                stop += 1 * Time.deltaTime;
                if (durationAcc <= stop)
                    stop = 0f;
            }
            else
            {
                vector = new Vector3((int)sideCameraMode * cameraModeSpeed, 0, 0);
                controller.Move(vector);
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, leftLim, rightLim), transform.position.y, transform.position.z);
                if (transform.position.x == leftLim || transform.position.x == rightLim)
                {
                    stop += 1 * Time.deltaTime;
                    if (sideCameraMode == SideOfCamera.LEFT)
                        sideCameraMode = SideOfCamera.RIGHT;
                    else
                        sideCameraMode = SideOfCamera.LEFT;
                }
            }
        }
    }
}
