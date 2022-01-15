using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "office", menuName = "New office object")]
public class OfficeObject : ScriptableObject
{
    public bool light_left;
    public bool door_left;
    public bool light_right;
    public bool door_right;
}
