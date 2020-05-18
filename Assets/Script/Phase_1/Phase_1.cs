using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phase_1 : MonoBehaviour
{
    public GameObject LetterButton, Letter;
    public GameObject selectDistr, bodyInfoPhase1, bodyTurnFild;
    public int[] bodyTurn;
    public Text bodyTurnText;
    public Text dayNum;

    public int dayWeek = 0;
    //private ShowLetter s;

    public static Phase_1 instance = null;

    public delegate void ClickAction();
    public static event ClickAction OnLetterQuest;

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

    public void OnDisable()
    {
        Debug.Log("OnDisable Phase_1");
        bodyTurnFild.SetActive(false);
        Letter.SetActive(false);

    }


    public void RulesEveryDay()
    {
        switch (dayWeek)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                //конец игры/ итоги
                break;
        }

    }



    public void OnEnable()
    {
        bodyTurnFild.SetActive(true);
        bodyTurnText.text = "" + bodyTurn[dayWeek];
      
        ShowChoiceDistr(false);
        Letter.SetActive(true);
        dayNum.text = ""+ (dayWeek+1); //+ (Info.instance.dayWeek + 1);

    }

    public void ShowLetter(GameObject t)
    {
        //создавать письмо (не обязательно?)
        //  Instantiate(t, new Vector3(0, 1, 0), Quaternion.identity);
        t.SetActive(true);
        if (OnLetterQuest != null)
            OnLetterQuest(); //?
        LetterButton.SetActive(false);
    }


    public void ShowChoiceDistr(bool a)
    {
        selectDistr.SetActive(a); 
        bodyInfoPhase1.SetActive(a); 
    }


    public void Burn()//сжечь тело, на вход нужно будет доавть экземпляр, но это позже 
    {
        Info.instance.money += BodyMove.instance.bodyInfo.money;
        Info.instance.SetMoneyInfo();

    }
}
