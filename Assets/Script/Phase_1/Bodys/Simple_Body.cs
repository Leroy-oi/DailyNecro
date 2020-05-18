using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
//[Serializable]
public class Simple_Body 
{
    public BodyPart partMainBody, partHead,partRightHand;
    public BodyPart partLeftHand,partLeftFoot,partRightFoot;


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

  /*  public enum Class
    {
        normal,
        doctor,
        rang_1,
        rang_2,
        rang_3,
        rang_4,
        criminal
    }
    */

    public bool sick = false;
    public int power=10, health=10, day=0, money=2;
    public string fullName;
    public Class type;
    /*  public  Simple_Body()
      {
         sick = false;
         power = 10;
         health = 10;
      }*/
}
