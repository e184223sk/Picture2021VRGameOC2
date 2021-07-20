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
    public bool[] IsGetW = new bool[10];
    public bool[] IsGetA = new bool[10];
    public bool RW, LW, A1, A2, A3;
    public int a, s, d, f, min , b ;
    public float sec, Osec, t;
    public Data[] DataBase;
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
        for (int t = 0; t < 10; t++)
        {
            if (IsGetW[t] == false)
            {
                RWeapon.texture = null;
                LWeapon.texture = null;
            }
            if (IsGetA[t] == false)
            {
                ability1.texture = null;
                ability2.texture = null;
                ability3.texture = null;
            }
        }
        Reload.text = "";
    }
    void Update()
    {
        //画像(未完了)
        for (int m = 0; m < 10; m++)
        {
            if (IsGetW[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    RW = true;
                    if (RW == true)
                    {
                        RWeapon.texture = DataBase[m].Wimage;
                    }
                }
            }
            if (IsGetW[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    LW = true;
                    if (LW == true)
                    {
                        LWeapon.texture = DataBase[m].Wimage;
                    }
                }
            }
            if (IsGetA[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    A1 = true;
                    if (A1 == true)
                    {
                        ability1.texture = DataBase[m].Aimage;
                    }
                }
            }
            if (IsGetA[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.V))
                {
                    A2 = true;
                    if (A2 == true)
                    {
                        ability2.texture = DataBase[m].Aimage;
                    }
                }
            }
            if (IsGetA[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    A3 = true;
                    if (A3 == true)
                    {
                        ability3.texture = DataBase[m].Aimage;
                    }
                }
            }
        }
        //時間
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
        //ポイント
        Point.text = "POINT ：" + a * s * d * f;
        //残弾
        if (b >= 0 && b < 6)
        {
            if (Input.GetKeyDown(KeyCode.A)) { b++; }
        }
        switch(b)
        {
            case 0: Barrage.text = "残弾：6/6";
                Reload.text = "";
                break;
            case 1:Barrage.text = "残弾：5/6";
                break;
            case 2:Barrage.text = "残弾：4/6";
                break;
            case 3:Barrage.text = "残弾：3/6";
                break;
            case 4:Barrage.text = "残弾：2/6";
                break;
            case 5:Barrage.text = "残弾：1/6";
                break;
            case 6:t += Time.deltaTime;
                Barrage.text = "残弾：0/6";
                Reload.text = "リロード中…";
                if (t >= 3)
                {
                    b -= 6;
                    t = 0;
                }
                break;
        }
        //ミニマップ
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
public class Data
{
    public Texture2D Wimage;
    public Texture2D Aimage;
}
