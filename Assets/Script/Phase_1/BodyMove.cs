using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
using UnityEditor;

public class BodyMove : MonoBehaviour
{
    public static BodyMove instance = null;


    public GameObject moveObj, cape;
    public Image body, head, l_hand,r_hand, l_foot, r_foot, face_scarm;
    public Image[] img;
    public Vector3 A, B, C;
    private Vector3 vector = new Vector3(0, 0, 0), target;
    private bool moveInCenter, openCape = false;
    public Text nameFild, moneyFild;

    public Body_Object_Info info; //всё помечено как image, но это объекты
    // public Body_Object_Clon clon;


    public Simple_Body bodyInfo = new Simple_Body();

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

    public Simple_Body ReturnBody()
    {
        return bodyInfo;
    }
    public void MoveToCenter()
    {
        createNew();
        cape.transform.localPosition = new Vector3(0, -5, 0);

        moveObj.transform.localPosition = A;
        vector = new Vector3(0, -5, 0);
        target = B;
        moveInCenter = true;
    }

    public void createNew()//Body_Object_Clon type)
    {//расписать тут создание нового клона
        //+ заполнение всех параметров

        Debug.Log("Вызов createNew");
        bodyInfo.fullName = info.firstName[Random.Range(0, info.firstName.Length - 1)] + " " + info.secondName[Random.Range(0, info.secondName.Length - 1)];
        nameFild.text = bodyInfo.fullName;

        int s = Random.Range(0, 10);
        // Присвоить enum(?)
        if (s>=5)
        {
            bodyInfo.partMainBody = info.partMainBody_m[Random.Range(0, info.partMainBody_m.Length - 1)];
            bodyInfo.partHead = info.partHead_m[Random.Range(0, info.partHead_m.Length - 1)];
            bodyInfo.gendre = "m";
        }
        else {
            bodyInfo.partMainBody = info.partMainBody_w[Random.Range(0, info.partMainBody_w.Length - 1)];
            bodyInfo.partHead = info.partHead_w[Random.Range(0, info.partHead_w.Length - 1)];
            bodyInfo.gendre = "w";
        }
   

        if (Phase_1.instance.dayWeek == 0)
        {
            bodyInfo.partLeftFoot = info.partLeftFoot[Random.Range(0, info.partLeftFoot.Length-1)];
            bodyInfo.partLeftHand = info.partLeftHand[Random.Range(0, info.partLeftHand.Length-1)];
            bodyInfo.partRightFoot = info.partRightFoot[Random.Range(0, info.partRightFoot.Length-1)];
            bodyInfo.partRightHand = info.partRightHand[Random.Range(0, info.partRightHand.Length-1)];
        }

        else
        {
            bodyInfo.partLeftFoot = info.partLeftFoot[Random.Range(0, info.partLeftFoot.Length)];
            bodyInfo.partLeftHand = info.partLeftHand[Random.Range(0, info.partLeftHand.Length)];
            bodyInfo.partRightFoot = info.partRightFoot[Random.Range(0, info.partRightFoot.Length)];
            bodyInfo.partRightHand = info.partRightHand[Random.Range(0, info.partRightHand.Length)];

        }
        bodyInfo.imageDopSkarm = info.imageDopSkarm[Random.Range(0, info.imageDopSkarm.Length - 1)];


        body.GetComponent<Image>().sprite = bodyInfo.partMainBody.part_img;
        head.GetComponent<Image>().sprite = bodyInfo.partHead.part_img;
        l_hand.GetComponent<Image>().sprite = bodyInfo.partLeftHand.part_img;
        r_hand.GetComponent<Image>().sprite = bodyInfo.partRightHand.part_img;
        l_foot.GetComponent<Image>().sprite = bodyInfo.partLeftFoot.part_img;
        r_foot.GetComponent<Image>().sprite = bodyInfo.partRightFoot.part_img;

        face_scarm.GetComponent<Image>().sprite = bodyInfo.imageDopSkarm;

        bodyInfo.money = Random.Range(1, 10);
        moneyFild.text = "" + bodyInfo.money;
    }

    public void MoveAway()
    {
        vector = new Vector3(0, -5, 0);
        moveInCenter = false;
        target = C;
        target.y = C.y;
        CapeClose();

    }
    void Start()
    {
        moveObj.transform.localPosition = A;
        vector = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Phase_1.instance.bodyTurn[Phase_1.instance.dayWeek] > 0)
            if (moveObj.transform.localPosition.y > target.y)
            {
                //   Debug.Log(body.transform.localPosition.y + " " + target.y);
                moveObj.transform.Translate(vector * Time.deltaTime);
            }
            else
            {
             
                vector = new Vector3(0, 0, 0);
                //проверять статус
                if (moveInCenter)
                    Phase_1.instance.ShowChoiceDistr(true);
                else
                {
                    Phase_1.instance.ShowChoiceDistr(false);
                    Phase_1.instance.bodyTurn[Phase_1.instance.dayWeek] -= 1;
                    Phase_1.instance.bodyTurnText.GetComponent<Text>().text = "" + Phase_1.instance.bodyTurn[Phase_1.instance.dayWeek];
                     MoveToCenter();
                }
            }
        else
        {
            Animations_master.instance.GoToNight();
         //   MenuManager.instance.ShowPhase_2();
        }
    }

    public void CapeMove()
    {
        if (!openCape)
        {
            float xx = -180;
            //cape.GetComponent<RectTransform>().width;
            Vector3 v = new Vector3(-0.01f, 0, 0);
            while (cape.transform.localPosition.x >= xx)
                cape.transform.Translate(v * Time.deltaTime);
            openCape = true;
        }
        else
            CapeClose();
    }
    public void CapeClose()
    {

        float xx = -180;
        //cape.GetComponent<RectTransform>().width;
        Vector3 v = new Vector3(0.01f, 0, 0);
        while (cape.transform.localPosition.x <= 0.0f)
            cape.transform.Translate(v * Time.deltaTime);
        openCape = false;
    }
}
