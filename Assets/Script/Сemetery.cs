using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сemetery : MonoBehaviour
{
    public Simple_Body b = new Simple_Body();
    public GameObject[] places;



    public void Full()
    {
        b = BodyMove.instance.bodyInfo;
        //BodyMove.instance.ReturnBody();//new BodyMove.instance.bodyInfo();//текущее тело
        for (int r = 0; r < places.Length; r++)
        {
            if (!places[r].GetComponent<BurialPlaces>().full)
            {
                Debug.Log("Тело захоронено в.." + r);
                places[r].GetComponent<BurialPlaces>().full = true;
                //это ссылка
                //places[r].GetComponent<BurialPlaces>().body= b;
                //
                places[r].GetComponent<BurialPlaces>().body.fullName = b.fullName;

                places[r].GetComponent<BurialPlaces>().body.imageMainBody = b.imageMainBody;
                places[r].GetComponent<BurialPlaces>().body.imageHead = b.imageHead;
                places[r].GetComponent<BurialPlaces>().body.imageRightHand = b.imageRightHand;
                places[r].GetComponent<BurialPlaces>().body.imageLeftHand = b.imageLeftHand;
                places[r].GetComponent<BurialPlaces>().body.imageLeftFoot = b.imageLeftFoot;
                places[r].GetComponent<BurialPlaces>().body.imageRightFoot = b.imageRightFoot;
                places[r].GetComponent<BurialPlaces>().body.imageDopSkarm = b.imageDopSkarm;
                places[r].GetComponent<BurialPlaces>().body.gendre = b.gendre;


                places[r].GetComponent<BurialPlaces>().index = r;
                places[r].GetComponent<BurialPlaces>().IsFool();
                break;
            }
        }
    }

}

