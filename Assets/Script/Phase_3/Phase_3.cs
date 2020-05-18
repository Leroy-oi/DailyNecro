using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phase_3 : MonoBehaviour
{

    public bool isGiving=true;//отдаём человеку
    public GameObject man, finishButton;
    public Sprite img_all, img_doctor, img_r1, img_r2, img_r3, img_r4, img_r5, img_crim;
    public Image goalType;
    public Animator anim;
   
    /*public enum Class
    {
        normal,//все
        doctor,
        rang_1,
        rang_2,
        rang_3,
        rang_4,
        criminal
    }*/

    public Goal goal;
    public Text textGoal;
    public static Phase_3 instance = null;
    public Army army;

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
    public void OnEnable()
    {
        anim.SetBool("isFinish", false);
        isGiving = true;

        goal = ReturnGoal();

        if (goal.type == Class.normal)
            goalType.sprite = img_all;
        if (goal.type == Class.doctor)
            goalType.sprite = img_doctor;
        if (goal.type == Class.rang_1)
            goalType.sprite = img_r1;
        if (goal.type == Class.rang_2)
            goalType.sprite = img_r2;
        if (goal.type == Class.rang_3)
            goalType.sprite = img_r3;
        if (goal.type == Class.rang_4)
            goalType.sprite = img_r4;
        if (goal.type == Class.criminal)
            goalType.sprite = img_crim;


        UpdateGoal();
        finishButton.SetActive(false);
        man.SetActive(true);
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

    public void UpdateGoal()
    {
        //менять картинку
        textGoal.text = "" + goal.size;
    }

    public void MinusGoal(Simple_Body body,int ind)
    {
        if (body.type == goal.type)
        {
            goal.size--;
            UpdateGoal();
            army.RemoveBody(ind);
            Debug.Log("цель = " + goal);
            if (goal.size <= 0)
            {
                anim.SetBool("isFinish", true);
                Finish();

            }
        }
    }

    public void Finish()
    {
        anim.SetBool("isFinish", false);
        isGiving = false;
        finishButton.SetActive(true);

    }

    public void StartNewDay()
    {
        man.SetActive(false);
        Animations_master.instance.GoToDay();
    }
}
