using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//описывет движение и содержание документа
public class ShowLetter : MonoBehaviour
{

    public GameObject textObj, titleObj;
    public Button button;
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
        texts[0] = "Ваша цель на сегодня...";
        texts[1] = ltext;
        texts[2] = "Сегодня у вас выходной.";
        texts[3] = "Нужны новые боевые единицы в количестве 5";
        texts[4] = "Нам необходимы врачи. Срочно!";
        texts[5] = "Обещают осадки из ядерного пепла";
        texts[6] = "ВНИМАНИЕ! В связи с введением военного положения, просим вас позаботиться о себе самостоятельно.";
        RandomText();

    }

    private void RandomText()
    {
        randomNum = Random.Range(0, 5);
        if (textObj)
            textObj.GetComponent<Text>().text = texts[randomNum];// ltext;
    }

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
        MenuManager.OnLetterQuest += Moving;
    }


    void OnDisable()
    {
        MenuManager.OnLetterQuest -= Moving;
    }

    public void Moving()
    {
        button.interactable = false;
        RandomText();
        //Random.Range[0,5];
        vector = new Vector2(0, 15);
        move = true;
        //Debug.Log("movingg");
    
    }

    public void Close()
    {
        MenuManager.instance.ShowPhase_1();
        transform.position =pos;
      
    }
}
