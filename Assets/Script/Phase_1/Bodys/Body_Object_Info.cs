using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "bodyBox_", menuName = "bodyBox")]
public class Body_Object_Info : ScriptableObject
{ //хранилище рандомных данных, что могут быть даны телу.
    public Sprite[] imageMainBody_w;
    public Sprite[] imageMainBody_m;
    public Sprite[] imageHead_w;
    public Sprite[] imageHead_m;
    public Sprite[] imageRightHand;
    public Sprite[] imageLeftHand;
    public Sprite[] imageLeftFoot;
    public Sprite[] imageRightFoot;

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
