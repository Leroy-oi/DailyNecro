using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BurialPlaces : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Simple_Body body = new Simple_Body();

    // public string name;
    // public Body_Object_Clon body=new Body_Object_Clon();
    public bool full;
    public int index; //место в массиве
    public Sprite sp, sp2;


    void Start()
    {
        IsFool();

    }


    public void IsFool()
    {

        if (full)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.2F, 0.3F, 0.4F);//new Vector4(0f, 0f, 0f, 1f);
            this.GetComponent<SpriteRenderer>().sprite = sp;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(0.4F, 0.7F, 0.1F);
            this.GetComponent<SpriteRenderer>().sprite = sp2;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Нажато");

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Отжато");

    }
    void OnMouseDown()
    {
        IsFool();
        if (full)
        {
            Debug.Log("MouseDown " + index);
            if (!Phase_2.instance.isDig)
            {
                MenuManager.instance.cemetryInfoCard.SetActive(true);
                MenuManager.instance.cemetryInfoCard_name.text = body.fullName;//
            }
            else
            {
                full = false;
                index = 0;
                Phase_2.instance.isDig = false;
                MenuManager.instance.ShowCoffin(body);
                Phase_2.instance.SetBody(body);
                body = null;
                IsFool();
                MenuManager.instance.Ph_2.Show3Buttons();
            }
            Phase_2.instance.IsItDig();
        }


    }
   
    void OnMouseUp()
    {

    }

    public void SetInfoAboutBody()
    {

    }
}
