using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public RawImage RWeapon;
    public RawImage LWeapon;
    public RawImage ability1;
    public RawImage ability2;
    public RawImage ability3;
    /*Image[] Weapon = new Image[30];
    Image[] ability = new Image[30];
        for(int e = 0;e< 30;e++)
        {
            Weapon[e] = GameObject.Find("Canvas/Weapon" + e).GetComponent<Image>();
            ability[e] = GameObject.Find("Canvas/ability" + e).GetComponent<Image>();
        }*/
    Text time;
    Text Reload;
    Text Point;
    public Text Barrage;
    public bool[] IsGetw = new bool[30];
    public bool[] IsGeta = new bool[30];
    public bool IsReload;
    public bool rk, lk;
    public int[] IsBarrage;
    public int a = 100, s = 3, d = 500, f = 5;
    public float TimeCount = 60.0f;
    public WeaponData[] DataBase;
    public AbilityData[] database;
    void Start()
    {
        Barrage = GameObject.Find("Canvas/Barrage").GetComponent<Text>();
        RWeapon = GameObject.Find("Canvas/RWeapon").GetComponent<RawImage>();
        LWeapon = GameObject.Find("Canvas/LWeapon").GetComponent<RawImage>();
        ability1 = GameObject.Find("Canvas/AbilityColumn/Ability1").GetComponent<RawImage>();
        ability2 = GameObject.Find("Canvas/AbilityColumn/Ability2").GetComponent<RawImage>();
        ability3 = GameObject.Find("Canvas/AbilityColumn/Ability3").GetComponent<RawImage>();
        time = GameObject.Find("Canvas/time").GetComponent<Text>();
        Point = GameObject.Find("Canvas/Point").GetComponent<Text>();
        Reload = GameObject.Find("Canvas/Reload").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //時間(未完了)
        time.text = string.Format("Time: {0:00.00}", TimeCount);
        TimeCount -= Time.deltaTime;
        //ポイント(未完了)
        Point.text = "POINT ：" + a * s * d * f;
        //リロード(完了)
        if (IsReload == true)
        {
            Reload.text = "リロード中…";
        }
        else
        {
            Reload.text = "";
        }
        //残弾(未完了)
        for(int q = 6;q >= 0;q--)
        {
            if (q == 6)
            {
                
            }
        }

        for (int t = 0; t < 30; t++)
        {
            if (rk == true && IsGetw[t] == true)
            {
                RWeapon.texture = DataBase[t].image;
            }
            else if (lk == true && IsGetw[t] == true)
            {
                LWeapon.texture = DataBase[t].image;
            }
            else
            {
                RWeapon.texture = null;
                LWeapon.texture = null;
            }
            if (IsGeta[t] == true)
            {
                ability1.texture = database[t].image;
                ability2.texture = database[t].image;
                ability3.texture = database[t].image;
            }
            else
            {
                ability1.texture = null;
                ability2.texture = null;
                ability3.texture = null;
            }
        }
        
    }
}

[System.Serializable]
public class WeaponData
{
    public Texture2D image;
}
public class AbilityData
{
    public Texture2D image;
}
