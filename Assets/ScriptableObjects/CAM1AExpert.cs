using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cam1a", menuName = "New camera expert")]
public class CAM1AExpert : ScriptableObject
{
    //public bool is_bonnie;
    //public bool is_chica;
    //public bool is_freddy;

    public Sprite _BCF;
    public Sprite _BF;
    public Sprite _CF;
    public Sprite _F;
    public Sprite _NONE;

    public Sprite getSprite(bool is_b, bool is_c, bool is_f)
    {
        if (is_b && is_f&& is_c)
            return _BCF;
        if (is_b && is_f)
            return _BF;
        if (is_c && is_f)
            return _CF;
        if (is_f)
            return _F;
        return _NONE;
    }
}
