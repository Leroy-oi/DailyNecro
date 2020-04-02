using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Animations_master : MonoBehaviour
{
    public static Animations_master instance = null;
    public GameObject night;
    private Color color;
    private SpriteRenderer render;

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
        //Debug.Log("цвет - " + night.GetComponent<SpriteRenderer>().color);
        GoToDay();
    }
    public void GoToNight()
    {
        night.SetActive(true);
        /*   night.SetActive(true);
           night.GetComponent<SpriteRenderer>().color = new Vector4(0f, 0f, 0f, 0f);
           render = night.GetComponent<SpriteRenderer>();
           float a = 0.0f;
           while (color.a < 1.0f)
           {
               a += 0.1f;
               render.color = new Vector4(0f, 0f, 0f, a);
               night.GetComponent<SpriteRenderer>().color = render.color;
           }*/

    }

    public void GoToDay()
    {
        night.SetActive(false);
        /*  night.SetActive(true);
          render = night.GetComponent<SpriteRenderer>();
          float a = 1.0f;
          while (render.color.a > 0.0f)
          {
              a -= 0.1f;
              render.color = new Vector4(0f, 0f, 0f, a);
              night.GetComponent<SpriteRenderer>().color = render.color;
          }
          night.SetActive(false);
          */
    }
}



