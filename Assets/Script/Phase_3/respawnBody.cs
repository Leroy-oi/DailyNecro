using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class respawnBody : MonoBehaviour
{
    public Simple_Body body;
    public int ind;
    private Button button;

  /*  void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {

            if (Phase_3.instance.isGiving)
            {
                Phase_3.instance.MinusGoal(ind);

            }
        }
        );
    }*/

    void OnMouseDown()
    {
        if (Phase_3.instance.isGiving)
        {
            Phase_3.instance.MinusGoal(body, ind);
            Debug.Log("Отработало");
        }
    }
}
