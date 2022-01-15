using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "camera", menuName = "New camera object")]
public class CamerasHelper : ScriptableObject
{
    public delegate void CameraHandler(bool mode);
    public event CameraHandler eventik;
    public void PutOnCamera(GameObject cameras, GameObject controllers)
    {
        cameras.SetActive(true);
        controllers.SetActive(true);
        eventik.Invoke(true);
    }
    public void PutOffCamera(GameObject cameras, GameObject controllers)
    {
        cameras.SetActive(false);
        controllers.SetActive(false);
        eventik.Invoke(false);
    }
}
