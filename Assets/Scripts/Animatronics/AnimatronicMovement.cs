using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicMovement : MonoBehaviour
{
    public CameraAnima cam1a;
    public Animatronics bonnie;
    public Animatronics chica;
    public Animatronics freddy;
    public float chanceReducer;
    public CameraClick[] cameras;
    public float timeStep = 0f;
    public float canMove = 5f;
    public OnError error;

    void Start()
    {
        #region Bonnie
        bonnie = new Animatronics();
        bonnie.camera = cam1a;
        bonnie.chanceReducer = 10;
        bonnie.name = "bonnie";
        #endregion
        #region Chica
        chica = new Animatronics();
        chica.camera = cam1a;
        chica.chanceReducer = 10;
        chica.name = "chica";
        #endregion
        #region Freddy
        freddy = new Animatronics();
        freddy.camera = cam1a;
        freddy.chanceReducer = 0;
        freddy.name = "freddy";
        #endregion
    }

    void FixedUpdate()
    {
        if (timeStep == 0)
        {
            float rand = UnityEngine.Random.value;
            string oldCamera = "";
            if (rand < bonnie.chanceReducer * chanceReducer)
            {
                rand = UnityEngine.Random.value;
                if (rand < bonnie.camera.stepBack_chance / bonnie.chanceReducer / bonnie.chanceReducer && bonnie.camera.stepBack != null)
                {
                    int randInt = UnityEngine.Random.Range(0, bonnie.camera.stepBack.Length);
                    oldCamera = bonnie.camera.cameraName;
                    if (bonnie.camera.stepBack[randInt].is_canBonnie&& !bonnie.camera.stepBack[randInt].is_animatronic)
                    {
                        bonnie.camera = bonnie.camera.stepBack[randInt];
                        Debug.Log($"0 {bonnie.camera.stepBack.Length}");
                        Debug.Log(randInt);
                        Step(bonnie.camera.cameraName, oldCamera);
                    }
                }
                else if (rand < bonnie.camera.stepForward_chance / bonnie.chanceReducer / bonnie.chanceReducer && bonnie.camera.stepForward != null)
                {
                    int randInt = UnityEngine.Random.Range(0, bonnie.camera.stepForward.Length);
                    oldCamera = bonnie.camera.cameraName;
                    if (bonnie.camera.stepForward[randInt].is_canBonnie&&!bonnie.camera.stepForward[randInt].is_animatronic)
                    {
                        bonnie.camera = bonnie.camera.stepForward[randInt];
                        Debug.Log($"0 {bonnie.camera.stepForward.Length}");
                        Debug.Log(randInt);
                        Step(bonnie.camera.cameraName, oldCamera);
                    }
                }

            }
        }
        else
        {
            timeStep += 1 * Time.deltaTime;
            if (timeStep >= canMove)
                timeStep = 0f;
        }
    }
    void Step(string camera, string oldCamera)
    {
        error.is_onError = true;
        CameraClick camera1 = null;
        CameraClick camera2 = null;
        foreach (var item in cameras)
        {
            if (item.cameraObject != null)
            {
                if (camera == item.cameraObject.cameraName)
                    camera1 = item;
                if (oldCamera == item.cameraObject.cameraName)
                    camera2 = item;
            }
        }
        camera2.view = camera2.cameraObject.standart;
        camera2.cameraObject.is_animatronic = false;
        camera2.Changed();
        int rand = UnityEngine.Random.Range(0, camera1.cameraObject.bonnie.Length);
        camera1.view = camera1.cameraObject.bonnie[rand];
        camera2.cameraObject.is_animatronic = true;
        camera1.Changed();
        timeStep += 1 * Time.deltaTime;
    }
}
