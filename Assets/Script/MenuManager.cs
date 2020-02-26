using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Choice, MainPlaces, Letter, sL, YesNo;
    public GameObject letterParent, letter;
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


    void Start()
    {
       if (Info.instance.newGame)
        {//закрываем все подменю на всякий
            Choice.SetActive(false);
            YesNo.SetActive(false);
            sL.SetActive(true);
            MainPlaces.SetActive(true);
        }
       else
        { //начало новой  игры
            Choice.SetActive(true);
            YesNo.SetActive(false);
            sL.SetActive(false);
            MainPlaces.SetActive(false);
        }
    }

    public void MakeChoice(int a) //выбор стороны
    {
        Debug.Log("Вы сделали выбор за сторону " + a+" !");
        Choice.SetActive(false);
        sL.SetActive(true);
        MainPlaces.SetActive(true);
        Info.instance.StartNewGame();
    }

    public void ShowLetter(GameObject t)
    {
        
       // t.SetActive(false);
        if (OnLetterQuest != null)
            OnLetterQuest();
        // s= Instantiate(letter, letterParent.transform).GetComponent<ShowLetter>();
        //  s.Moving();
    }

    public void CloseLetter(GameObject f)
    {
        //Destroy(f);
        //f.SetActive(false);
    }

    public void ShowPhase_1()
    {
        YesNo.SetActive(true);
    }




}
