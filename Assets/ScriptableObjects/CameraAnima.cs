using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "camera", menuName = "New camera animatronic object")]
public class CameraAnima : ScriptableObject
{
    public string cameraName;
    public bool is_animatronic;
    public float stepForward_chance;
    public float stepBack_chance;
    public bool is_canMoveHere;
    public CameraAnima[] stepForward;
    public CameraAnima[] stepBack;
    public bool is_canBonnie;
    public bool is_canChica;
    public bool is_canFreddy;

    [Header("Sprites")]
    public Sprite standart;

    public Sprite[] bonnie;
    public Sprite[] chica;
    public Sprite[] freddy;
}
