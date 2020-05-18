using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffinMove : MonoBehaviour
{

   // public static BodyMove instance = null;


    public GameObject moveObj, cape;
    public Image body, head, l_hand, r_hand, l_foot, r_foot, face_scarm;
    public Image[] img;
    public Vector3 A, B, C;
    private Vector3 vector = new Vector3(0, 0, 0), target;
    private bool moveInCenter, openCap = false;
    public Text nameFild, moneyFild;

    public Body_Object_Info info;
    // public Body_Object_Clon clon;


    public Simple_Body bodyInfoCoffin = new Simple_Body();

    public static CoffinMove instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }


    public void OpenCoffin()
    {
        if (!openCap)
        {
            float xx = -180;
            //cape.GetComponent<RectTransform>().width;
            Vector3 v = new Vector3(-0.01f, 0, 0);
            while (cape.transform.localPosition.x >= xx)
                cape.transform.Translate(v * Time.deltaTime);
            openCap = true;
        }
        else
            CloseCoffin();
    }

    public void CloseCoffin()
    {
        float xx = -180;
        //cape.GetComponent<RectTransform>().width;
        Vector3 v = new Vector3(0.01f, 0, 0);
        while (cape.transform.localPosition.x <= 0.0f)
            cape.transform.Translate(v * Time.deltaTime);
        openCap = false;
    }

    public void PushInfo(Simple_Body bodyIn)//Body_Object_Clon type)
    {//расписать тут создание нового клона
        //+ заполнение всех параметров
        bodyInfoCoffin.fullName = bodyIn.fullName;

        bodyInfoCoffin.partMainBody = bodyIn.partMainBody;
        bodyInfoCoffin.partHead = bodyIn.partHead;
        bodyInfoCoffin.partLeftFoot = bodyIn.partLeftFoot;
        bodyInfoCoffin.partLeftHand = bodyIn.partLeftHand;
        bodyInfoCoffin.partRightFoot = bodyIn.partRightFoot;
        bodyInfoCoffin.partRightHand = bodyIn.partRightHand;

        bodyInfoCoffin.imageDopSkarm = bodyIn.imageDopSkarm;

        body.GetComponent<Image>().sprite = bodyInfoCoffin.partMainBody.part_img;
        head.GetComponent<Image>().sprite = bodyInfoCoffin.partHead.part_img;
        l_hand.GetComponent<Image>().sprite = bodyInfoCoffin.partLeftHand.part_img;
        r_hand.GetComponent<Image>().sprite = bodyInfoCoffin.partRightHand.part_img;
        l_foot.GetComponent<Image>().sprite = bodyInfoCoffin.partLeftFoot.part_img;
        r_foot.GetComponent<Image>().sprite = bodyInfoCoffin.partRightFoot.part_img;
        nameFild.text = bodyInfoCoffin.fullName;
        face_scarm.GetComponent<Image>().sprite = bodyInfoCoffin.imageDopSkarm;
    }

   
}
