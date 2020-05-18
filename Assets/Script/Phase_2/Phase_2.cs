using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phase_2 : MonoBehaviour
{
    public GameObject twoButtons, threeButtons, artDigButton, artTakeButton;

    public Texture2D cursorTextureDig, cursorTextureKnife;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject coffin;
    public GameObject circle, redText; //круг призыва

    public GameObject L_hand, R_hand, L_foot, R_foot;
    public BodyPart LH, RH, LF, RF;

    public static Phase_2 instance = null;
    public Simple_Body openBody;
    public Army respawnBody;
    public Text knifeButtonText, cottonText;
    public bool isDig = false, isTakePart = false;


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



    void OnEnable()
    {
        UpdateCotton();
        redText.SetActive(false);
        Show2Buttons();
        coffin.SetActive(false);
        circle.SetActive(true);
        SetKnifeAbout();

    }

    public void SetKnifeAbout()
    {
        if (Info.instance.knife)
        {
            knifeButtonText.text = "Взять часть";
        }
        else
        {
            knifeButtonText.text = "Купить нож";
        }
    }

    public void IsItTakePart()
    {
        if (isTakePart)
        {
            artTakeButton.SetActive(false);
            Cursor.SetCursor(cursorTextureKnife, hotSpot, cursorMode);
        }
        else
        {
            artTakeButton.SetActive(true);
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public void IsItDig()
    {
        if (isDig)
        {
            artDigButton.SetActive(false);
            Cursor.SetCursor(cursorTextureDig, hotSpot, cursorMode);
        }
        else
        {
            artDigButton.SetActive(true);
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public void TakePart()
    {
        if (Info.instance.knife)
        {
            if (!isTakePart)
                isTakePart = true;
            else
                isTakePart = false;
            IsItTakePart();
        }
        else
        {
            //открыть магаз
            MenuManager.instance.OpenShop();
        }
    }

    void OnDisable()
    {
        circle.SetActive(false);
    }
    public void StartDig()
    {
        if (!isDig)
        {
            isDig = true;
        }
        else
        {
            isDig = false;
        }
        IsItDig();
    }



    public void Burn()//сжечь тело, на вход нужно будет доавть экземпляр, но это позже 
    {
        if (!isTakePart)
        {
            Info.instance.money += BodyMove.instance.bodyInfo.money;
            Info.instance.SetMoneyInfo();
            MenuManager.instance.UnshowCoffin();
            openBody = null;
            Show2Buttons();
        }
    }

    public void SetBody(Simple_Body b)
    {
        openBody = b;
    }


    public bool AllFull()
    {
       if(!openBody.partLeftFoot.full)
        {
            return false;
        }
        if (!openBody.partLeftHand.full)
        {
            return false;
        }
        if (!openBody.partRightFoot.full)
        {
            return false;
        }
        if (!openBody.partRightHand.full)
        {
            return false;
        }
        return true;
    }

    public void Respawn()
    {
        if (!isTakePart)
        {
            if (AllFull())
            {
                respawnBody.SetLiveNewOne(openBody);
                openBody = null;
                MenuManager.instance.UnshowCoffin();
                Show2Buttons();
            }
            else
            {
                redText.SetActive(true);
                Debug.Log("Тело не целое, воскрешение невозможно");
            }
        }
    }
    public void Show3Buttons()
    {
        CheckCard();
        twoButtons.SetActive(false);
        threeButtons.SetActive(true);
    }
    public void Show2Buttons()
    {
        twoButtons.SetActive(true);
        threeButtons.SetActive(false);
    }

    public void CheckCard()
    {
        if (RH == null)
        {
            R_hand.SetActive(false);
        }
        else
            R_hand.SetActive(true);

        if (LH == null)
        {
            L_hand.SetActive(false);
        }
        else
            L_hand.SetActive(true);


        if (RF == null)
        {
            R_foot.SetActive(false);
        }
        else
            R_foot.SetActive(true);

        if (LF == null)
        {
            L_foot.SetActive(false);
        }
        else
            L_foot.SetActive(true);
    }

    public void UpdateCotton()
    {
        cottonText.text = "" + Info.instance.cotton;
    }


    public void Add_LH()
    {
        if (LH != null)//запасная проверка
            if (!openBody.partLeftHand.full)
            {
                openBody.partLeftHand = LH;
                CoffinMove.instance.bodyInfoCoffin.partLeftHand = LH;
                CoffinMove.instance.l_hand.GetComponent<Image>().sprite =LH.part_img;
                LH = null;
            }
        CheckCard();
    }
    public void Add_RH()
    {
        if (RH != null)//запасная проверка
            if (!openBody.partRightHand.full)
            {
                if (Info.instance.cotton > 0)
                {
                    Info.instance.cotton--;
                    openBody.partRightHand = RH;
                    CoffinMove.instance.bodyInfoCoffin.partRightHand = RH;
                    CoffinMove.instance.r_hand.GetComponent<Image>().sprite = RH.part_img;
                    RH = null;
                }
            }
        CheckCard();
    }
    public void Add_LF()
    {
        if (LF != null)//запасная проверка
            if (!openBody.partLeftFoot.full)
            {
                openBody.partLeftFoot = LF;
                CoffinMove.instance.bodyInfoCoffin.partLeftFoot= LF;
                CoffinMove.instance.l_foot.GetComponent<Image>().sprite = LF.part_img;
                LF = null;
            }
        CheckCard();
    }
    public void Add_RF()
    {
        if (RF != null)//запасная проверка
            if (!openBody.partRightFoot.full)
            {
                openBody.partRightFoot = RF;
                CoffinMove.instance.bodyInfoCoffin.partRightFoot = RF;
                CoffinMove.instance.r_foot.GetComponent<Image>().sprite = RF.part_img;
                RF = null;
            }
        CheckCard();
    }

    public void Take_LH()
    {
        if (isTakePart)
        {
            if (openBody.partLeftHand.full)
            {
                if (LH == null)
                {
                    LH = openBody.partLeftHand;
                    openBody.partLeftHand = BodyMove.instance.info.null_L_hand;
                    CoffinMove.instance.bodyInfoCoffin.partLeftHand = BodyMove.instance.info.null_L_hand;
                    CoffinMove.instance.l_hand.GetComponent<Image>().sprite = BodyMove.instance.info.null_L_hand.part_img;

                }
            }
            else
            {
                openBody.partLeftHand = BodyMove.instance.info.null_L_hand;
                CoffinMove.instance.bodyInfoCoffin.partLeftHand = BodyMove.instance.info.null_L_hand;
                CoffinMove.instance.l_hand.GetComponent<Image>().sprite = BodyMove.instance.info.null_L_hand.part_img;
            }
        }
        CheckCard();
    }
    public void Take_RH()
    {
        if (isTakePart)
        {
            if (openBody.partRightHand.full)
            {
                if (RH == null)
                {
                    RH = openBody.partRightHand;
                    openBody.partRightHand = BodyMove.instance.info.null_R_hand;
                    CoffinMove.instance.bodyInfoCoffin.partRightHand = BodyMove.instance.info.null_R_hand;
                    CoffinMove.instance.r_hand.GetComponent<Image>().sprite = BodyMove.instance.info.null_R_hand.part_img;
                }
            }
            else
            {
                openBody.partRightHand = BodyMove.instance.info.null_R_hand;
                CoffinMove.instance.bodyInfoCoffin.partRightHand = BodyMove.instance.info.null_R_hand;
                CoffinMove.instance.r_hand.GetComponent<Image>().sprite = BodyMove.instance.info.null_R_hand.part_img;
            }
        }
        CheckCard();
    }
    public void Take_RF()
    {
        if (isTakePart)
        {
            if (openBody.partRightFoot.full)
            {
                if (RF == null)
                {
                    RF = openBody.partRightFoot;
                    openBody.partRightFoot = BodyMove.instance.info.null_R_foot;
                    CoffinMove.instance.bodyInfoCoffin.partRightFoot = BodyMove.instance.info.null_R_foot;
                    CoffinMove.instance.r_foot.GetComponent<Image>().sprite = BodyMove.instance.info.null_R_foot.part_img;

                }
            }
            else
            {
               openBody.partRightFoot = BodyMove.instance.info.null_R_foot;
                CoffinMove.instance.bodyInfoCoffin.partRightFoot = BodyMove.instance.info.null_R_foot;
                CoffinMove.instance.r_foot.GetComponent<Image>().sprite = BodyMove.instance.info.null_R_foot.part_img;
            }
        }
        CheckCard();
    }
    public void Take_LF()
    {
        if (isTakePart)
        {
            if (openBody.partLeftFoot.full)
            {
                if (LF == null)
                {
                    LF = openBody.partLeftFoot;
                    openBody.partLeftFoot = BodyMove.instance.info.null_L_foot;
                    CoffinMove.instance.bodyInfoCoffin.partLeftFoot = BodyMove.instance.info.null_L_foot;
                    CoffinMove.instance.l_foot.GetComponent<Image>().sprite = BodyMove.instance.info.null_L_foot.part_img;

                }
            }
            else
            {
                openBody.partLeftFoot = BodyMove.instance.info.null_L_foot;
                CoffinMove.instance.bodyInfoCoffin.partLeftFoot = BodyMove.instance.info.null_L_foot;
                CoffinMove.instance.l_foot.GetComponent<Image>().sprite = BodyMove.instance.info.null_L_foot.part_img;

            }
        }

        CheckCard();
    }
}