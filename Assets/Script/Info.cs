using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//этот код хранит все данные и действия
public class Info : MonoBehaviour
{
    public static Info instance = null;
    public MenuManager MM;
    public int a = 3;
   
    public int money = 0;
    public bool newGame = false; //начата ли новая игра (т.е. есть ли сохранение)
    public bool knife = false;
    public int cotton=10; //нитки для сшивания
    public int wood=10;//на самом деле гробы, можно забить на материалы
    public GameObject moneyText;
    public Text woodText;
    public int woodPrice, cottonPrice, knifePrice;
   /* public enum Class
    {
        normal,//все
        doctor,
        rang_1,
        rang_2,
        rang_3,
        rang_4,
        criminal
    }*/
    public Goal goal_1, goal_2, goal_3, goal_4, goal_5, goal_6, goal_7;// = new Goal(Class.normal, 3);
// цель
    public enum SideStatus//за какую сторону
    {
        A,
        B,
        Null
    }
    public enum GameStatus
    {
        Start,
        Choice,
        Returning,
        Army,
        End
    }




    public SideStatus SS = SideStatus.Null;
    public GameStatus AA = GameStatus.Start;


    void Awake() //работает до любых start
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("клон уничтожен / ошибка " + gameObject);
            Destroy(gameObject);
        }


        UpdateWood();
        LoadInfo();
        SetMoneyInfo();

       
        // объект не уничтожается при переходе на другую сцену игры
        //  DontDestroyOnLoad(gameObject);

    }



    public void LoadInfo()
    {
        if(!PlayerPrefs.HasKey("Side"))
             newGame = false;
        else
        {
            newGame = true;
            string side = PlayerPrefs.GetString("Side");
            if (side.Equals("A"))
            { SS = SideStatus.A; }
            else
                if (side.Equals("B"))
            { SS = SideStatus.B; }
        }
     
        if (!PlayerPrefs.HasKey("Gold"))
            money = PlayerPrefs.GetInt("Gold");
    }

    public void SaveInfo()
    {
        if (SS==SideStatus.A)
        PlayerPrefs.SetString("Side", "A");
        else
        if (SS==SideStatus.B)
            PlayerPrefs.SetString("Side", "B");

        PlayerPrefs.SetInt("Gold",money);

    }

    public void UpdateWood()
    {
        woodText.text = "" + wood;
    }

    public void SetMoneyInfo()
    {
        moneyText.GetComponent<Text>().text = "" + money;
    }

  

    public void StartNewGame()
    {
        newGame = true;
        wood = 10;
        StartPhase_1();
       
    }

    public void StartPhase_1()
    {
        if (AA == GameStatus.Start)
        {
            Debug.Log("hah");
        AA = GameStatus.Choice; }
        MM.ShowPhase_1();
    }

    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        MenuManager.StartPh_1 += W;
    }

    void OnDisable()
    {
        SaveInfo();
        MenuManager.StartPh_1 -= W;
     
    }

    public void W()
    {
        Debug.Log("whaa..");
       // MM.T();
    }
    void OnApplicationQuit()
    {
        SaveInfo();
    }

     
}
