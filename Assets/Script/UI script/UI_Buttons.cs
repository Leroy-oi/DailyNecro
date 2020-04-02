using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.SceneManagement; using UnityEngine.UI; 

public class UI_Buttons : MonoBehaviour
{

  public void CloseWindow(GameObject window)
    { window.SetActive(false); }

    public void OpenWindow(GameObject window)
    { window.SetActive(true); }

    public void OpenMainScene() //игра
    {
        SceneManager.LoadScene(1);
    }


    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void OpenStartScene() //стартовое меню
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
