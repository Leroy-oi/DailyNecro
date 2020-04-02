using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//этот код хранит все данные и действия
public class Info : MonoBehaviour
{
    public static Info instance = null;
    public MenuManager MM;
    public int a=3;
    public int money = 0;
    public bool newGame = false; //начата ли новая игра (т.е. есть ли сохранение)
    public GameObject moneyText;
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


    public void SetMoneyInfo()
    {
        moneyText.GetComponent<Text>().text = "" + money;
    }

    void Awake() //работает до любых start
    {
        LoadInfo(); 
        SetMoneyInfo();

        if (instance == null)
        {
            instance = this; 
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // объект не уничтожается при переходе на другую сцену игры
      //  DontDestroyOnLoad(gameObject);

    }

    public void StartNewGame()
    {
        newGame = true;
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
