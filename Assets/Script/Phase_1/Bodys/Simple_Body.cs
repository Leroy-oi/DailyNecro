using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//[Serializable]
public class Simple_Body 
{
    public Sprite imageMainBody;

    public Sprite imageHead;
    public Sprite imageRightHand;
    public Sprite imageLeftHand;
    public Sprite imageLeftFoot;
    public Sprite imageRightFoot;


    public Sprite imageDopSkarm;
    public string gendre="non";
   /* public enum Sex
    {
        W,
        M
    }*/
    public enum Side
    {
        A,
        B,
        C
    }
    public bool sick = false;
    public int power=10, health=10, lifetime=10, money=2;
    public string fullName;
   /*  public  Simple_Body()
     {
        sick = false;
        power = 10;
        health = 10;
     }*/
}
