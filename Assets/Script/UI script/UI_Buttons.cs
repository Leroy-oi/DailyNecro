using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.SceneManagement; using UnityEngine.UI; 

public class UI_Buttons : MonoBehaviour
{
 
    public void OpenMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
