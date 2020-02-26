using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//описывет движение и содержание документа
public class ShowLetter : MonoBehaviour
{

    public GameObject textObj, titleObj, button;
    private string ltext = "Это текст, который будет браться из специального дока, что будет написан позже.";

    private string[] texts = new string[7];
    private int randomNum;
    private bool move;
    private Vector2 vector;
    private Vector3 pos;
    void Start()
    {
    pos = transform.position;
        button.GetComponent<Button>().onClick.AddListener(() =>
        Close());
        button.SetActive(false);
        texts[0] = "Ваша цель на сегодня...";
        texts[1] = ltext;
        texts[2] = "Сегодня у вас выходной.";
        texts[3] = "Нужны новые боевые единицы в количестве 5";
        texts[4] = "Нам необходимы врачи. Срочно!";
        texts[5] = "Обещают осадки из ядерного пепла";
        texts[6] = "ВНИМАНИЕ! В связи с введением военного положения, просим вас позаботиться о себе самостоятельно.";
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
        ShowButton();
        }
    }

    private void ShowButton()
    {
        button.SetActive(true);
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
         //Random.Range[0,5];
        vector = new Vector2(0, 10);
        move = true;
        Debug.Log("movingg");
    
    }

    public void Close()
    {
        MenuManager.instance.ShowPhase_1();
        //Vector3 pos = transform.position;
        //pos.y = Random.Range(1.0f, 3.0f);
        transform.position =pos;
        //transform.Translate(0,0,0);
       // Destroy(gameObject);
    }
}
