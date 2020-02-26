using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот код хранит все данные и действия
public class Info : MonoBehaviour
{
    public static Info instance = null;
    public MenuManager MM;
    public int a=3;
   public bool newGame = false; //начата ли новая игра (т.е. есть ли сохранение)
    GameStatus AA= GameStatus.Start;
    public enum GameStatus
    {
        Start,
        Choice,
        Returning,
        Army,
        End
    }

    void Awake() //работает до любых start
    {
       
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
        MenuManager.StartPh_1 -= W;
     
    }

    public void W()
    {
        Debug.Log("whaa..");
       // MM.T();
    }
}
