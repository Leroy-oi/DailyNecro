using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    public GameObject[] theyObj;
    public Simple_Body[] they;
    void Awake()
    {
        they = new Simple_Body[theyObj.Length];
        for (int y = 0; y < theyObj.Length; y++)
        {
            theyObj[y].SetActive(false);
        }
      
    }

    public void SetLiveNewOne(Simple_Body body)
    {
        for(int y=0; y< theyObj.Length; y++)
        {
            if (theyObj[y].activeSelf ==false)
            {
                they[y]=body;
                theyObj[y].SetActive(true);
                theyObj[y].GetComponent<respawnBody>().ind = y;
                theyObj[y].GetComponent<respawnBody>().body = body;
                break;
            }
        }
    }
    public void RemoveBody(int ind)
    {
        theyObj[ind].SetActive(false);
        theyObj[ind].GetComponent<respawnBody>().body = null;
        they[ind] = null;
       
    }

}
