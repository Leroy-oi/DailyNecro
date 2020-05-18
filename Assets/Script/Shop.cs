using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text price_wood, price_cotton, price_knife, price_place;
    public Text have_wood, have_cotton, have_knife, have_place;
    public GameObject redText;

    void Awake()
    {
        redText.SetActive(false);
    }
    public void UpdateText()
    { if (Info.instance)
        price_wood.text = "" + Info.instance.woodPrice;
        price_cotton.text = "" + Info.instance.cottonPrice;
        price_knife.text = "" + Info.instance.knifePrice;

        have_wood.text = "" + Info.instance.wood;
        have_cotton.text= "" + Info.instance.cotton;
       if (Info.instance.knife)
        {
            have_knife.text = "есть";
            //делать кнопку нерабочей
        }
        else have_knife.text = "нет";
    }


    public void SetAnim()//?
    {
        redText.SetActive(true);
        Debug.Log("не хватает денег");
    }

    public void BuyWood()
    {
        if (Info.instance.money >= Info.instance.woodPrice)
        {
            Info.instance.money -= Info.instance.woodPrice;
            Info.instance.wood++;
            UpdateText();
            Info.instance.UpdateWood();
            Info.instance.SetMoneyInfo();
        }
        else SetAnim();
    }

    public void BuyCotton()
    {
        if (Info.instance.money >= Info.instance.cottonPrice)
        {
            Info.instance.money -= Info.instance.cottonPrice;
            Info.instance.cotton++;
            UpdateText();
            Phase_2.instance.UpdateCotton();
            Info.instance.SetMoneyInfo();
        }
        else SetAnim();
    }

    public void BuyKnife()
    {
        if (!Info.instance.knife)
        {
            if (Info.instance.money >= Info.instance.knifePrice)
            {
                Info.instance.money -= Info.instance.knifePrice;
                Info.instance.knife = true;
                UpdateText();
                Info.instance.SetMoneyInfo();
                Phase_2.instance.SetKnifeAbout();
            }
        }
        else SetAnim();
    }

    public void BuyPlace()
    {
        //если можно и нельзая купить
        //увеличение массива мест
        //можно как вычитать и одного массива и добавлять в другой
        //так и.. не, первый варик лучше
    }


}
