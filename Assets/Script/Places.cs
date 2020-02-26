using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Places : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log("" + Info.instance.a);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("MouseDown");
    }
    void OnMouseUp()
    {
        Debug.Log("MouseUp");
    }
}
