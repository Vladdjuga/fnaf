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
    public OfficeObject office;
    public float stepFromDoorChance = 10;
    public CameraAnima camLeftDoor;
    public CameraAnima camRightDoor;
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
            float anum = UnityEngine.Random.Range(1, 3);
            string oldCamera = "";
            if (!office.is_bonnie) {
                if (anum == 1)
                {
                    if (rand < bonnie.chanceReducer * chanceReducer)
                    {
                        rand = UnityEngine.Random.value;
                        if (rand < bonnie.camera.stepBack_chance / bonnie.chanceReducer / bonnie.chanceReducer && bonnie.camera.stepBack != null)
                        {
                            int randInt = UnityEngine.Random.Range(0, bonnie.camera.stepBack.Length);
                            oldCamera = bonnie.camera.cameraName;
                            if (bonnie.camera.stepBack[randInt].is_canBonnie && !bonnie.camera.stepBack[randInt].is_animatronic)
                            {
                                bonnie.camera = bonnie.camera.stepBack[randInt];
                                //Debug.Log($"0 {bonnie.camera.stepBack.Length}");
                                //Debug.Log(randInt);
                                Step(bonnie.camera.cameraName, oldCamera, bonnie);
                            }
                        }
                        else if (rand < bonnie.camera.stepForward_chance / bonnie.chanceReducer / bonnie.chanceReducer && (bonnie.camera.stepForward != null || bonnie.camera.is_fin))
                        {
                            if (!bonnie.camera.is_fin)
                            {
                                Debug.Log("2");
                                int randInt = UnityEngine.Random.Range(0, bonnie.camera.stepForward.Length);
                                oldCamera = bonnie.camera.cameraName;
                                if (bonnie.camera.stepForward[randInt].is_canBonnie && !bonnie.camera.stepForward[randInt].is_animatronic)
                                {
                                    bonnie.camera = bonnie.camera.stepForward[randInt];
                                    //Debug.Log($"0 {bonnie.camera.stepForward.Length}");
                                    //Debug.Log(randInt);
                                    Step(bonnie.camera.cameraName, oldCamera, bonnie);
                                }
                            }
                            else
                            {
                                oldCamera = bonnie.camera.cameraName;
                                Debug.Log("1");
                                bonnie.is_inDoor = true;
                                office.is_bonnie = true;
                                StepToDoor(oldCamera);
                            }
                        }
                    }
                }
            }
            else
            {
                if(rand<stepFromDoorChance* chanceReducer)
                {
                    bonnie.is_inDoor = false;
                    office.is_bonnie = false;
                    StepFromDoor(camLeftDoor.cameraName, bonnie);
                }
            }
            if (!office.is_chica)
            {
                if (anum == 2)
                {
                    if (rand < chica.chanceReducer * chanceReducer)
                    {
                        rand = UnityEngine.Random.value;
                        if (rand < chica.camera.stepBack_chance / chica.chanceReducer / chica.chanceReducer && chica.camera.stepBack != null)
                        {
                            int randInt = UnityEngine.Random.Range(0, chica.camera.stepBack.Length);
                            oldCamera = chica.camera.cameraName;
                            if (chica.camera.stepBack[randInt].is_canChica && !chica.camera.stepBack[randInt].is_animatronic)
                            {
                                chica.camera = chica.camera.stepBack[randInt];
                                //Debug.Log($"0 {chica.camera.stepBack.Length}");
                                //Debug.Log(randInt);
                                Step(chica.camera.cameraName, oldCamera, chica);
                            }
                        }
                        else if (rand < chica.camera.stepForward_chance / chica.chanceReducer / chica.chanceReducer && (chica.camera.stepForward != null || chica.camera.is_fin))
                        {
                            if (!chica.camera.is_fin)
                            {
                                int randInt = UnityEngine.Random.Range(0, chica.camera.stepForward.Length);
                                oldCamera = chica.camera.cameraName;
                                if (chica.camera.stepForward[randInt].is_canChica && !chica.camera.stepForward[randInt].is_animatronic)
                                {
                                    chica.camera = chica.camera.stepForward[randInt];
                                    //Debug.Log($"0 {chica.camera.stepForward.Length}");
                                    //Debug.Log(randInt);
                                    Step(chica.camera.cameraName, oldCamera, chica);
                                }
                            }
                            else
                            {
                                oldCamera = chica.camera.cameraName;
                                Debug.Log("1");
                                chica.is_inDoor = true;
                                office.is_chica = true;
                                StepToDoor(oldCamera);
                            }
                        }
                    }
                }
            }
            else
            {
                if (rand < stepFromDoorChance * chanceReducer)
                {
                    chica.is_inDoor = false;
                    office.is_chica = false;
                    StepFromDoor(camRightDoor.cameraName, chica);
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
    public Sprite[] GetAnimatronicSpritesByName(string _name,CameraAnima obj)
    {
        return (Sprite[])typeof(CameraAnima).GetField(_name).GetValue(obj);
    }
    void Step(string camera, string oldCamera,Animatronics animatronic)
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
        if (camera2.is_HOMECAM)
        {
            if (animatronic.name == "bonnie")
                camera2.is_bonnie = false;
            if (animatronic.name == "chica")
                camera2.is_chica = false;
            if (animatronic.name == "freddy")
                camera2.is_freddy = false;
            camera2.UpdateCam();
        }
        else
        {
            if(camera2.cameraObject!=null)
                camera2.view = camera2.cameraObject.standart;
            camera2.cameraObject.is_animatronic = false;
            camera2.Changed();
        }
        if (camera1.cameraObject.standart != null)
        {
            Sprite[] sprites = GetAnimatronicSpritesByName(animatronic.name, camera1.cameraObject);
            if (sprites.Length > 0)
            {
                int rand = UnityEngine.Random.Range(0, sprites.Length);
                camera1.view = sprites[rand];
            }
        }
        camera1.cameraObject.is_animatronic = true;
        camera1.Changed();
        timeStep += 1 * Time.deltaTime;
    }
    void StepToDoor(string oldCamera)
    {
        error.is_onError = true;
        CameraClick camera2 = null;
        foreach (var item in cameras)
        {
            if (item.cameraObject != null)
            {
                if (oldCamera == item.cameraObject.cameraName)
                    camera2 = item;
            }
        }
        camera2.view = camera2.cameraObject.standart;
        camera2.cameraObject.is_animatronic = false;
        camera2.Changed();
        timeStep += 1 * Time.deltaTime;
    }
    void StepFromDoor(string oldCamera,Animatronics animatronic)
    {
        error.is_onError = true;
        CameraClick camera2 = null;
        foreach (var item in cameras)
        {
            if (item.cameraObject != null)
            {
                if (oldCamera == item.cameraObject.cameraName)
                    camera2 = item;
            }
        }
        if (camera2.cameraObject.standart != null)
        {
            Sprite[] sprites = GetAnimatronicSpritesByName(animatronic.name, camera2.cameraObject);
            if (sprites.Length > 0)
            {
                int rand = UnityEngine.Random.Range(0, sprites.Length);
                camera2.view = sprites[rand];
            }
        }
        camera2.cameraObject.is_animatronic = true;
        camera2.Changed();
        timeStep += 1 * Time.deltaTime;
    }
}
