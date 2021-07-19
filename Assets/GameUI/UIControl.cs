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
    Image[] Weapon = new Image[30];
    Image[] ability = new Image[30];
    /*    for(int e = 0;e f< 30;e++)
        {
            Weapon[e] = GameObject.Find("Canvas/Weapon" + e).GetComponent<Image>();
            ability[e] = GameObject.Find("Canvas/ability" + e).GetComponent<Image>();
        }*/
    public Text time;
    public Text Reload;
    public Text Point;
    public Text Barrage;
    public bool[] IsGetw = new bool[30];
    public bool[] IsGeta = new bool[30];
    public bool rk, lk;
    public int a, s, d, f, min;
    public float TimeCount = 60.0f, sec, Osec;
    public WeaponData[] DataBase;
    public AbilityData[] database;
    void Start()
    {
        for (int e = 0; e < 30; e++)
            RWeapon = GameObject.Find("Canvas/RWeapon").GetComponent<RawImage>();
        LWeapon = GameObject.Find("Canvas/LWeapon").GetComponent<RawImage>();
        ability1 = GameObject.Find("Canvas/Ability/Ability1").GetComponent<RawImage>();
        ability2 = GameObject.Find("Canvas/Ability/Ability2").GetComponent<RawImage>();
        ability3 = GameObject.Find("Canvas/Ability/Ability3").GetComponent<RawImage>();
        Barrage = GameObject.Find("Canvas/Barrage").GetComponent<Text>();
        time = GameObject.Find("Canvas/time").GetComponent<Text>();
        Point = GameObject.Find("Canvas/Point").GetComponent<Text>();
        Reload = GameObject.Find("Canvas/Reload").GetComponent<Text>();
        min = 5;
        sec = 60F;
        Osec = 60F;
    }
    void Update()
    {
        //時間(未完了)
        sec -= Time.deltaTime;
        if (sec <= 0F)
        {
            min--;
            //sec = sec + 60;
        }
        if ((int)sec != (int)Osec)
        {
            time.text = min.ToString("04") + ":" + ((int)sec).ToString("00");
        }
        Osec = sec;
        //ポイント(完了)
        Point.text = "POINT ：" + a * s * d * f;
        //残弾(完了?)
        for (int b = 6; b >= 0; b--)
        {
            Reload.text = "";
            switch (b)
            {
                case 1:
                    if (b == 6)
                    {
                        Barrage.text = "残弾：6/6";
                    }
                    break;

                case 2:
                    if (b == 5)
                    {
                        Barrage.text = "残弾：5/6";
                    }
                    break;
                case 3:
                    if (b == 4)
                    {
                        Barrage.text = "残弾：4/6";
                    }
                    break;
                case 4:
                    if (b == 3)
                    {
                        Barrage.text = "残弾：6/6";
                    }
                    break;
                case 5:
                    if (b == 2)
                    {
                        Barrage.text = "残弾：6/6";
                    }
                    break;
                case 6:
                    if (b == 1)
                    {
                        Barrage.text = "残弾：1/6";
                    }
                    break;
                case 7:
                    if (b == 0)
                    {
                        Barrage.text = "残弾：0/6";
                        //リロード
                        for (float t = 0.0F; t < 3.0F; t += Time.deltaTime)
                        {
                            if (t < 3.0F)
                            {

                                Reload.text = "リロード中…";
                            }
                            else
                            {
                                Reload.text = "";
                            }
                        }
                        b += 6;
                    }
                    break;
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
                if (ability[t]) { ability1.texture = database[t].image; }
                if (ability[t]) { ability2.texture = database[t].image; }
                if (ability[t]) { ability3.texture = database[t].image; }

                else
                {
                    ability1.texture = null;
                    ability2.texture = null;
                    ability3.texture = null;
                }
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
