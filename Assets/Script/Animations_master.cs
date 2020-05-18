using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Animations_master : MonoBehaviour
{
    public static Animations_master instance;
    private Color color;
    private SpriteRenderer render;
    public Animator anim;

    void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
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
        //Debug.Log("цвет - " + night.GetComponent<SpriteRenderer>().color);
        GoToDay();
    }
    public void GoToNight()
    {


anim.SetBool("isDay",false);

}

    public void GoToDay()
    {

        anim.SetBool("isDay", true);

    }


    //евенты в анимации
    public void ItIsDay()
    {
        Phase_1.instance.dayWeek += 1;
        // MenuManager.instance.ShowPhase_1();
        MenuManager.instance.LetterButton.SetActive(true);//запускается после прочтения письма
        MenuManager.instance.Letter.SetActive(true);
         Debug.Log("наступил день");

    }



    public void ItIsNight()
    {
       MenuManager.instance.ShowPhase_2();
        Debug.Log("наступила ночь");
    }
}



