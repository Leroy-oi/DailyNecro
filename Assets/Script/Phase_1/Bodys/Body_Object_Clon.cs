using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// НЕ ИСПОЛЬЗУЕТСЯ (?)

[CreateAssetMenu(fileName = "body_", menuName = "new body")]
public class Body_Object_Clon : ScriptableObject
{
    public Sprite imageMain;
    public Sprite imageDop;
    public enum Side
    {
        A,
        B,
        C
    }
    public bool sick = false;
    public int power, health, lifetime;
    public string name;
}