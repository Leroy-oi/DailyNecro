using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bodyPart_", menuName = "bodyPart")]
[System.Serializable]

public class BodyPart : ScriptableObject
{
    public Sprite part_img;
    public bool full,partNull; //если часть целая и если к этому можно крепить
    public int day;
    public void OnMouseOver()
    {
        if(Phase_2.instance)
        {
           if( Phase_2.instance.isTakePart)
            {
            //    part_img.color = new Color(0.2F, 0.3F, 0.4F);
            }
        }
    }
}
