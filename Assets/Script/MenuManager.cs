using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Choice, MainPlaces, LetterButton, Letter, UI;
    public GameObject Ph_3;
    public Phase_1 Ph_1;
    public Phase_2 Ph_2;
    public GameObject doc_1, doc_2, doc_3;
    public CoffinMove coffin;
    public GameObject cemetryInfoCard, circle;
    public Shop shop;
    public Text cemetryInfoCard_name;
    public bool isShop;

    private int phaseNow = 1;
    public static MenuManager instance = null;



    public delegate void ClickAction();
    public static event ClickAction StartPh_1;
    public static event ClickAction StartPh_2;
    public static event ClickAction StartPh_3;



    void Awake()
    {

        if (phaseNow == 1)
            ShowPhase_1();
        else
        if (phaseNow == 2)
            ShowPhase_2();
        else
        if (phaseNow == 3)
            ShowPhase_3();
        else
        {
            ShowPhase_1();
        }


        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        circle.SetActive(false);
        shop.gameObject.SetActive(false);
        isShop = false;
    }



    public void Start()
    {
        CloseDocumentWindows();

        if ((Info.instance.newGame) && (Info.instance.SS != Info.SideStatus.Null))
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
            Ph_1.gameObject.SetActive(false);
            Ph_3.gameObject.SetActive(false);
            Ph_2.gameObject.SetActive(false);
        }
        //  Letter.SetActive(true);
        cemetryInfoCard.SetActive(false);
    }

    public void CloseDocumentWindows()
    {
        doc_1.SetActive(false);
        doc_2.SetActive(false);
        doc_3.SetActive(false);
    }

    public void MakeChoiceA()
    {
        UI.SetActive(true);
        Info.instance.SS = Info.SideStatus.A;
        Debug.Log("Вы сделали выбор за сторону !");
        Choice.SetActive(false);
        MainPlaces.SetActive(true);
        Ph_1.gameObject.SetActive(true);
        Info.instance.StartNewGame();
    }

    public void MakeChoiceB()
    {
        UI.SetActive(true);
        Info.instance.SS = Info.SideStatus.B;
        Debug.Log("Вы сделали выбор за сторону !");
        Choice.SetActive(false);
        MainPlaces.SetActive(true);
        Ph_1.gameObject.SetActive(true);
        Info.instance.StartNewGame();
    }



    public void ShowPhase_1() //фаза выбора
    {
        Ph_1.gameObject.SetActive(true);
        Ph_2.gameObject.SetActive(false);
        Ph_3.gameObject.SetActive(false);
        Letter.SetActive(true);
    }

    public void ShowPhase_2()
    {
        Ph_2.gameObject.SetActive(true);
        Ph_1.gameObject.SetActive(false);
        Ph_3.gameObject.SetActive(false);
        Letter.SetActive(false);
    }

    public void ShowPhase_3()
    {
        if (!Phase_2.instance.isDig)
        {
            Ph_3.gameObject.SetActive(true);
            Ph_2.gameObject.SetActive(false);
            Ph_1.gameObject.SetActive(false);
        }

    }

    public void ShowCoffin(Simple_Body b)
    {
        coffin.gameObject.SetActive(true);
        coffin.PushInfo(b);
    }

    public void UnshowCoffin()
    {
        coffin.gameObject.SetActive(false);
    }

   
    public void OpenShop()
    {
        if (isShop)
            shop.gameObject.SetActive(false);
        else
        {
            shop.gameObject.SetActive(true);
            shop.UpdateText();
        }
    }
}
