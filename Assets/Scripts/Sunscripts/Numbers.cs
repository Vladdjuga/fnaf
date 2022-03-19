using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "numbers", menuName = "New numbers expert")]
public class Numbers : ScriptableObject
{
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public Sprite s0;

    public Sprite getSprite(int index)
    {
        switch (index)
        {
            case 1:
                return s1;
            case 2:
                return s2;
            case 3:
                return s3;
            case 4:
                return s4;
            case 5:
                return s5;
            case 6:
                return s6;
            case 7:
                return s7;
            case 8:
                return s8;
            case 9:
                return s9;
            case 0:
                return s0;
            default:
                return s0;
        }
    }
}
