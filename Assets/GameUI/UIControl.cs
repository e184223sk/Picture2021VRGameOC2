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
    public bool RW, LW, A1, A2, A3, Lobby;
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
        Lobby = true;
    }
    void Update()
    {
        //画像
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
        if(Lobby == false)
        {
            //時間
            sec -= Time.deltaTime;
            if (sec <= 0F)
            {
                min--;
                sec = sec + 60;
            }
            if ((int)sec != (int)Osec)
            {
                time.text = "TIME ：　" + min.ToString("00") + ":" + ((int)sec).ToString("00");
            }
            Osec = sec;
            //ポイント
            Point.text = "POINT ：　" + a * s * d * f;
        }
        else
        {
            time.text = "";
            Point.text = "";
        }
        if( RWeapon.texture == true || LWeapon.texture == true)
        {
            //残弾
            if (b <= 30 && b > 0)
            {
                if (Input.GetKeyDown(KeyCode.A)) { b--; }
            }
            switch (b)
            {
                case 0:
                    t += Time.deltaTime;
                    Barrage.text = "残弾： 0/30";
                    Reload.text = "リロード中…";
                    if (t >= 3)
                    {
                        b += 30;
                        t = 0;
                    }
                    break;
                case 1:
                    Barrage.text = "残弾： 1/30";
                    break;
                case 2:
                    Barrage.text = "残弾： 2/30";
                    break;
                case 3:
                    Barrage.text = "残弾： 3/30";
                    break;
                case 4:
                    Barrage.text = "残弾： 4/30";
                    break;
                case 5:
                    Barrage.text = "残弾： 5/30";
                    break;
                case 6:
                    Barrage.text = "残弾： 6/30";
                    break;
                case 7:
                    Barrage.text = "残弾： 7/30";
                    break;
                case 8:
                    Barrage.text = "残弾： 8/30";
                    break;
                case 9:
                    Barrage.text = "残弾： 9/30";
                    break;
                case 10:
                    Barrage.text = "残弾： 10/30";
                    break;
                case 11:
                    Barrage.text = "残弾： 11/30";
                    break;
                case 12:
                    Barrage.text = "残弾： 12/30";
                    break;
                case 13:
                    Barrage.text = "残弾： 13/30";
                    break;
                case 14:
                    Barrage.text = "残弾： 14/30";
                    break;
                case 15:
                    Barrage.text = "残弾： 15/30";
                    break;
                case 16:
                    Barrage.text = "残弾： 16/30";
                    break;
                case 17:
                    Barrage.text = "残弾： 17/30";
                    break;
                case 18:
                    Barrage.text = "残弾： 18/30";
                    break;
                case 19:
                    Barrage.text = "残弾： 19/30";
                    break;
                case 20:
                    Barrage.text = "残弾： 20/30";
                    break;
                case 21:
                    Barrage.text = "残弾： 21/30";
                    break;
                case 22:
                    Barrage.text = "残弾： 22/30";
                    break;
                case 23:
                    Barrage.text = "残弾： 23/30";
                    break;
                case 24:
                    Barrage.text = "残弾： 24/30";
                    break;
                case 25:
                    Barrage.text = "残弾： 25/30";
                    break;
                case 26:
                    Barrage.text = "残弾： 26/30";
                    break;
                case 28:
                    Barrage.text = "残弾： 28/30";
                    break;
                case 29:
                    Barrage.text = "残弾： 29/30";
                    break;
                case 30:
                    Barrage.text = "残弾： 30/30";
                    Reload.text = "";
                    break;
            }
        }
        else
        {
            Barrage.text = "";
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
