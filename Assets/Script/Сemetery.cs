using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Сemetery : MonoBehaviour
{
    public Simple_Body b = new Simple_Body();
    public GameObject[] places;


    public void newDay()
    {
        for (int r = 0; r < places.Length; r++)
        {
            if (places[r].GetComponent<BurialPlaces>().full)
            {
                places[r].GetComponent<BurialPlaces>().body.day += 1;
            }
            places[r].GetComponent<BurialPlaces>().IsFool();
        }

    }

    public void Full()
    {
        if (Info.instance.wood > 0)
        {
            Info.instance.wood--;
            Info.instance.UpdateWood();
            // b = BodyMove.instance.ReturnBody();// bodyInfo;
            //BodyMove.instance.ReturnBody();//new BodyMove.instance.bodyInfo();//текущее тело
            for (int r = 0; r < places.Length; r++)
            {
                if (!places[r].GetComponent<BurialPlaces>().full)
                {
                    Debug.Log("Тело захоронено в.." + r);

                    //это ссылка
                    //places[r].GetComponent<BurialPlaces>().body= b;
                    //
                    if (BodyMove.instance.bodyInfo == null)
                    {
                        Debug.Log("пусто");
                        BodyMove.instance.createNew();
                    }
                    try
                    {
                        places[r].GetComponent<BurialPlaces>().body = BodyMove.instance.ReturnBody();
                        /* places[r].GetComponent<BurialPlaces>().body.fullName = BodyMove.instance.bodyInfo.fullName;
                      places[r].GetComponent<BurialPlaces>().body.partMainBody = BodyMove.instance.bodyInfo.partMainBody;
                      places[r].GetComponent<BurialPlaces>().body.partHead = BodyMove.instance.bodyInfo.partHead;
                      places[r].GetComponent<BurialPlaces>().body.partRightHand = BodyMove.instance.bodyInfo.partRightHand;
                      places[r].GetComponent<BurialPlaces>().body.partLeftHand = BodyMove.instance.bodyInfo.partLeftHand;
                      places[r].GetComponent<BurialPlaces>().body.partLeftFoot = BodyMove.instance.bodyInfo.partLeftFoot;
                      places[r].GetComponent<BurialPlaces>().body.partRightFoot = BodyMove.instance.bodyInfo.partRightFoot;
                      places[r].GetComponent<BurialPlaces>().body.imageDopSkarm = BodyMove.instance.bodyInfo.imageDopSkarm;
                      places[r].GetComponent<BurialPlaces>().body.gendre = BodyMove.instance.bodyInfo.gendre;
                      */
                    }
                    catch (Exception e)
                    {
                        Debug.Log("ОШИБКА " + e);
                        Debug.Log(" объект " + BodyMove.instance.bodyInfo);
                    }
                    Debug.Log(" объект2 " + BodyMove.instance.bodyInfo);
                    places[r].GetComponent<BurialPlaces>().index = r;
                    places[r].GetComponent<BurialPlaces>().full = true;
                    places[r].GetComponent<BurialPlaces>().IsFool();

                    break;
                }
            }
        }
    }
}
