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

    public Body_Object_Info info;
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
        bodyInfo.fullName = info.firstName[Random.Range(0, info.firstName.Length - 1)] + " " + info.secondName[Random.Range(0, info.secondName.Length - 1)];
        nameFild.text = bodyInfo.fullName;

        int s = Random.Range(0, 10);
        Debug.Log("s= " + s);
        // Присвоить enum(?)
        if (s>=5)
        {
            bodyInfo.imageMainBody = info.imageMainBody_m[Random.Range(0, info.imageMainBody_m.Length - 1)];
            bodyInfo.imageHead = info.imageHead_m[Random.Range(0, info.imageHead_m.Length - 1)];
            bodyInfo.gendre = "m";
        }
        else {
            bodyInfo.imageMainBody = info.imageMainBody_w[Random.Range(0, info.imageMainBody_w.Length - 1)];
            bodyInfo.imageHead = info.imageHead_w[Random.Range(0, info.imageHead_w.Length - 1)];
            bodyInfo.gendre = "w";
        }
       

        bodyInfo.imageLeftFoot = info.imageLeftFoot[Random.Range(0, info.imageLeftFoot.Length - 1)];
        bodyInfo.imageLeftHand = info.imageLeftHand[Random.Range(0, info.imageLeftHand.Length - 1)];
        bodyInfo.imageRightFoot = info.imageRightFoot[Random.Range(0, info.imageRightFoot.Length - 1)];
        bodyInfo.imageRightHand = info.imageRightHand[Random.Range(0, info.imageRightHand.Length - 1)];

        bodyInfo.imageDopSkarm = info.imageDopSkarm[Random.Range(0, info.imageDopSkarm.Length - 1)];


        body.GetComponent<Image>().sprite = bodyInfo.imageMainBody;
        head.GetComponent<Image>().sprite = bodyInfo.imageHead;
        l_hand.GetComponent<Image>().sprite = bodyInfo.imageLeftHand;
        r_hand.GetComponent<Image>().sprite = bodyInfo.imageRightHand;
        l_foot.GetComponent<Image>().sprite = bodyInfo.imageLeftFoot;
        r_foot.GetComponent<Image>().sprite = bodyInfo.imageRightFoot;

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
        if (MenuManager.instance.bodyTurn > 0)
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
                    MenuManager.instance.ShowChoiceDistr(true);
                else
                {
                    MenuManager.instance.ShowChoiceDistr(false);
                    MenuManager.instance.bodyTurn -= 1;
                    MenuManager.instance.bodyTurnText.text = "" + MenuManager.instance.bodyTurn;
                     MoveToCenter();
                }
            }
        else
        {
            Animations_master.instance.GoToNight();
            MenuManager.instance.ShowPhase_2();
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
