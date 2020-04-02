using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
  
    private void save()
    {
        #region PlayerPrefs.Set***
        string playerSide = "null";
        PlayerPrefs.SetString("Side", playerSide);
        int money =0;
        PlayerPrefs.SetInt("God", money);
        #endregion
    }

}
