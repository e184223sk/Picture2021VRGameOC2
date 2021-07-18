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
    public Text time;
    public Text Reload;
    public Text Point;
    public RawImage[] Weapon = new RawImage[30];
    public RawImage[] ability = new RawImage[30];
    public int[] Barrage = new int[6];
    public bool[] IsGetw = new bool[30];
    public bool[] IsGeta = new bool[30];
    public bool IsReload;
    public bool rk, lk;
    public int a = 100, s = 3, d = 500, f = 5;
    int min;
    float sec, Osec;
    public WeaponData[] DataBase;
    public AbilityData[] database;
    void Start()
    {
        RWeapon = GameObject.Find("Canvas/RWeapon").GetComponent<RawImage>();
        LWeapon = GameObject.Find("Canvas/LWeapon").GetComponent<RawImage>();
        ability1 = GameObject.Find("Canvas/AbilityColumn/Ability1").GetComponent<RawImage>();
        ability2 = GameObject.Find("Canvas/AbilityColumn/Ability2").GetComponent<RawImage>();
        ability3 = GameObject.Find("Canvas/AbilityColumn/Ability3").GetComponent<RawImage>();
        time = GameObject.Find("Canvas/Time").GetComponent<Text>();
        Point = GameObject.Find("Canvas/Point").GetComponent<Text>();
        min = 0;
        sec = 0f;
        Osec = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //時間
        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            min++;
            sec = sec - 60;
        }
        if ((int)sec != (int)Osec)
        {
            time.text = "TIME :" + min.ToString("00") + ";" + ((int)sec).ToString("00");
        }
        //ポイント
        Point.text = "POINT :" + (a * s) + (d * f);
        //リロード
        if (IsReload == true)
        {
            Reload.text = "リロード中…";
        }
        else
        {
            Reload.text = "";
        }

        for (int t = 0; t < 30; t++)
        {
            if (rk == true && IsGetw[t] == true)
            {
                RWeapon = Weapon[t];
            }
            else if (lk == true && IsGetw[t] == true)
            {
                LWeapon = Weapon[t];
            }
            else
            {
                RWeapon = null;
                LWeapon = null;
            }
            if (IsGeta[t] == true) { ability1 = ability[t]; }
            if (IsGeta[t] == true) { ability2 = ability[t]; }
            if (IsGeta[t] == true) { ability3 = ability[t]; }
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
