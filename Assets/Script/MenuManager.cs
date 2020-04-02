using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Choice, MainPlaces, LetterButton, Letter,UI;
    public GameObject Ph_1, Ph_2, Ph_3;
    public GameObject selectDistr, bodyInfo;
    public GameObject doc_1, doc_2, doc_3;
    public GameObject cemetryInfoCard;
    public Text cemetryInfoCard_name;
    //
    public int bodyTurn = 7; //очередь (скольких обрабатываем) 
    //вычислять отдельно, но пока так
    public Text bodyTurnText;

    private ShowLetter s;
    public static MenuManager instance = null;

  

    public delegate void ClickAction();
    public static event ClickAction OnLetterQuest;
    public static event ClickAction StartPh_1;
    public static event ClickAction StartPh_2;
    public static event ClickAction StartPh_3;

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

   public void Start()
    {
     bodyTurnText.text = "" + bodyTurn;
        CloseDocumentWindows();
        ShowChoiceDistr(false);
       if ((Info.instance.newGame)&&(Info.instance.SS!=Info.SideStatus.Null))
        {//закрываем все подменю на всякий
            Choice.SetActive(false);
            UI.SetActive(true);
            MainPlaces.SetActive(true);
        }
       else
        { //начало новой  игры
            UI.SetActive(false);
            Choice.SetActive(true);
            MainPlaces.SetActive(false);
            Ph_1.SetActive(false);
            Ph_3.SetActive(false);
            Ph_2.SetActive(false);
        }
        Letter.SetActive(true);
        cemetryInfoCard.SetActive(false);
    }

    public void CloseDocumentWindows()
    { doc_1.SetActive(false);
        doc_2.SetActive(false);
        doc_3.SetActive(false);
    }

    public void  MakeChoiceA()
    {
        UI.SetActive(true);
        Info.instance.SS = Info.SideStatus.A;
        Debug.Log("Вы сделали выбор за сторону !");
        Choice.SetActive(false);
        MainPlaces.SetActive(true);
        Ph_1.SetActive(true);
        Info.instance.StartNewGame();
    }

    public void MakeChoiceB()
    {
        UI.SetActive(true);
        Info.instance.SS = Info.SideStatus.B;
        Debug.Log("Вы сделали выбор за сторону !");
        Choice.SetActive(false);
        MainPlaces.SetActive(true);
        Ph_1.SetActive(true);
        Info.instance.StartNewGame();
    }


    public void ShowLetter(GameObject t)
    {
        //создавать письмо (не обязательно?)
      //  Instantiate(t, new Vector3(0, 1, 0), Quaternion.identity);
        if (OnLetterQuest != null)
            OnLetterQuest(); //?
      LetterButton.SetActive(false);
    }

    public void ShowChoiceDistr(bool a)
    {
        selectDistr.SetActive(a); ;
         bodyInfo.SetActive(a); ;
    }

    public void ShowPhase_1() //фаза выбора
    {
        Ph_1.SetActive(true);
        Ph_2.SetActive(false);
        Ph_3.SetActive(false);
        Letter.SetActive(true);
    }

    public void ShowPhase_2()
    {
        Ph_2.SetActive(true);
        Ph_1.SetActive(false);
        Ph_3.SetActive(false);
        Letter.SetActive(false);
    }

    public void ShowPhase_3()
    {
        Ph_3.SetActive(true);
        Ph_2.SetActive(false);
        Ph_1.SetActive(false);
    }

    public void Burn()//сжечь тело, на вход нужно будет доавть экземпляр, но это позже 
    {
        Info.instance.money += BodyMove.instance.bodyInfo.money;
        Info.instance.SetMoneyInfo();

    }
}
