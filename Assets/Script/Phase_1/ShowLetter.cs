using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//описывет движение и содержание документа
public class ShowLetter : MonoBehaviour
{

    public GameObject textGoal_type, textGoal_size, titleObj;
    public Button button;
    public Goal goal;
    public Class c;
    private string ltext = "Это текст, который будет браться из специального дока, что будет написан позже.";

    private string[] texts = new string[7];
    private int randomNum;
    private bool move;
    private Vector2 vector;
    private Vector3 pos;
    void Start()
    {
    pos = transform.position;
        button.onClick.AddListener(() =>
        Close());
        /* texts[0] = "Ваша цель на сегодня...";
         texts[1] = ltext;
         texts[2] = "Сегодня у вас выходной.";
         texts[3] = "Нужны новые боевые единицы в количестве 5";
         texts[4] = "Нам необходимы врачи. Срочно!";
         texts[5] = "Обещают осадки из ядерного пепла";
         texts[6] = "ВНИМАНИЕ! В связи с введением военного положения, просим вас позаботиться о себе самостоятельно.";
         */
        // RandomText();
        ShowText();
    }

    public Goal ReturnGoal()
    {
        if (Phase_1.instance.dayWeek == 0)
            return Info.instance.goal_1;
        if (Phase_1.instance.dayWeek == 1)
            return Info.instance.goal_2;
        if (Phase_1.instance.dayWeek == 2)
            return Info.instance.goal_3;
        if (Phase_1.instance.dayWeek == 3)
            return Info.instance.goal_4;
        if (Phase_1.instance.dayWeek == 4)
            return Info.instance.goal_5;
        if (Phase_1.instance.dayWeek == 5)
            return Info.instance.goal_6;
        if (Phase_1.instance.dayWeek == 6)
            return Info.instance.goal_7;
        return null;
    }




    public void ShowText()
    {
        goal = ReturnGoal();
        string strType="";
        if (goal.type == Class.normal)
            strType = "Любые люди";
        if (goal.type == Class.doctor)
            strType = "Врачи";
        if (goal.type == Class.rang_1)
            strType = "Военные 1 ранга и выше";
        if (goal.type == Class.rang_2)
            strType = "Военные 2 ранга и выше";
        if (goal.type == Class.rang_3)
            strType = "Военные 3 ранга и выше";
        if (goal.type == Class.rang_4)
            strType = "Военные 4 ранга";

        if (goal.type == Class.criminal)
            strType = "Преступники";

        textGoal_type.GetComponent<Text>().text = strType;

                textGoal_size.GetComponent<Text>().text =""+ goal.size;
    }

   /* private void RandomText()
    {
        randomNum = Random.Range(0, 5);
        if (textObj)
            textObj.GetComponent<Text>().text = texts[randomNum];// ltext;
    }*/

    private void Update()
    {
        if (!move) return;
        transform.Translate(vector*Time.deltaTime);
        if (transform.position.y >= 0.0)
        {
            move = false; 
            button.interactable = true;
        }
    }

    void OnEnable()
    {
        Phase_1.OnLetterQuest += Moving;
    }


    void OnDisable()
    {
        Phase_1.OnLetterQuest -= Moving;
    }

    public void Moving()
    {
        button.interactable = false;
        //        RandomText();
        //Random.Range[0,5];
        ShowText();
        vector = new Vector2(0, 15);
        move = true;
//         Debug.Log("movingg");
    
    }

    public void Close()
    {
       Debug.Log("работает закрытие письма");
        MenuManager.instance.ShowPhase_1();
        transform.position =pos;
      
    }
}
