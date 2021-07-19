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
    public RawImage MiniMap;
    public Rect uvRect;
    public Text time;
    public Text Reload;
    public Text Point;
    public Text Barrage;
    public bool[] IsGetw = new bool[2];
    public bool[] IsGeta = new bool[3];
    public int a, s, d, f, min , b ;
    public float sec, Osec, t;
    public WeaponData[] DataBase = new WeaponData[10];
    public AbilityData[] database = new AbilityData[10];
    public float speed;
    float x = 0.0f, y = 0.0f;
    void Start()
    {
        RWeapon = GameObject.Find("Canvas/RWeapon").GetComponent<RawImage>();
        LWeapon = GameObject.Find("Canvas/LWeapon").GetComponent<RawImage>();
        ability1 = GameObject.Find("Canvas/Ability/Ability1").GetComponent<RawImage>();
        ability2 = GameObject.Find("Canvas/Ability/Ability2").GetComponent<RawImage>();
        ability3 = GameObject.Find("Canvas/Ability/Ability3").GetComponent<RawImage>();
        MiniMap = GameObject.Find("Canvas/MiniMap").GetComponent<RawImage>();
        MiniMap.uvRect = new Rect(0, 0, 0.1f, 0.1f);
        Barrage = GameObject.Find("Canvas/Barrage").GetComponent<Text>();
        time = GameObject.Find("Canvas/time").GetComponent<Text>();
        Point = GameObject.Find("Canvas/Point").GetComponent<Text>();
        Reload = GameObject.Find("Canvas/Reload").GetComponent<Text>();
        min = 4;
        sec = 60F;
        Osec = 0;
        
    }
    void Update()
    {
        //時間(完了)
        sec -= Time.deltaTime;
        if (sec <= 0F)
        {
            min--;
            sec = sec + 60;
        }
        if ((int)sec != (int)Osec)
        {
            time.text = "TIME ：" + min.ToString("00") + ":" + ((int)sec).ToString("00");
        }
        Osec = sec;
        //ポイント(完了)
        Point.text = "POINT ：" + a * s * d * f;
        //残弾(完了)
        if (b >= 0 && b < 6)
        {
            if (Input.GetKeyDown(KeyCode.A)) { b++; }
        }
        Reload.text = "";
        if (b == 0) { Barrage.text = "残弾：6/6"; }
        if (b == 1) { Barrage.text = "残弾：5/6"; }
        if (b == 2) { Barrage.text = "残弾：4/6"; }
        if (b == 3) { Barrage.text = "残弾：3/6"; }
        if (b == 4) { Barrage.text = "残弾：2/6"; }
        if (b == 5) { Barrage.text = "残弾：1/6"; }
        if (b == 6)
        {
            t += Time.deltaTime;
            Barrage.text = "残弾：0/6";
            Reload.text = "リロード中…";
            if (t >= 3)
            {
                b -= 6;
                t = 0;
            }
        }
        //画像(未完了)
        for (int t = 0; t < 10; t++)
        {
            if (IsGetw[0] == true)
            {
                RWeapon.texture = DataBase[t].image;
            }
            if (IsGetw[1] == true)
            {
                LWeapon.texture = DataBase[t].image;
            }
            if (IsGeta[0] == true)
            {
                ability1.texture = database[t].image;
            }
            if (IsGeta[1] == true)
            {
                ability2.texture = database[t].image;
            }
            if (IsGeta[2] == true)
            {
                ability3.texture = database[t].image;
            }
        }

        if (x < 0) x = 0;
        if (x > 1) x = 1;
        if (y < 0) y = 0;
        if (y > 1) y = 1;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                y += speed;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                y -= speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                x -= speed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                x += speed;
            }
            MiniMap.uvRect = new Rect(x, y, 0.1f, 0.1f);
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
