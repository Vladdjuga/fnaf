﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "camera", menuName = "New animatronic object")]
public class Animatronics 
{
    [Header("Addons")]
    public string name;
    public float chanceReducer;
    public bool is_inDoor;

    [Header("Animatronics camera")]
    public CameraAnima camera;


}
