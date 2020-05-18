using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "bodyBox_", menuName = "bodyBox")]
public class Body_Object_Info : ScriptableObject
{ //хранилище рандомных данных, что могут быть даны телу.
    public BodyPart[] partMainBody_w;
    public BodyPart[] partMainBody_m;
    public BodyPart[] partHead_w;
    public BodyPart[] partHead_m;
    public BodyPart[] partRightHand;
    public BodyPart[] partLeftHand;
    public BodyPart[] partLeftFoot;
    public BodyPart[] partRightFoot;
    public BodyPart null_L_hand, null_R_hand, null_L_foot, null_R_foot;
    public Sprite[] imageDopSkarm;


    public enum Sex
    {
        W,
        M
    }

    public enum Side
    {
        A,
        B,
        C
    }
    public string[] firstName; //имя 
    public string[] secondName;//фамилия

}


/*
  using UnityEngine;
using System.Collections;
using UnityEditor;

public class MakeScriptableObject {
    [MenuItem("Assets/Create/My Scriptable Object")]
    public static void CreateMyAsset()
    {
        MyScriptableObjectClass asset = ScriptableObject.CreateInstance<MyScriptableObjectClass>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
    }

 */
