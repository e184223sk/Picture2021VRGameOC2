using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public RawImage RWeapon;
    public RawImage LWeapon;
    public RawImage ability;
    public RawImage MiniMap;
    public Rect uvRect;
    public Text time;
    public Text Point;
    public Text RBarrage;
    public Text LBarrage;
    public Slider Rweaponslider;
    public Slider Lweaponslider;
    public bool[] IsGetW = new bool[10];//当たり判定
    public bool[] IsGetA = new bool[10];//当たり判定その2
    public bool RWeaponTrigger, LWeaponTrigger, ABILITY, Lobby;
    public int point,length, min , Rbarrage ,RMaxbarrage, Lbarrage, LMaxbarrage;
    public float sec, Osec;
    public Data[] DataBase;
    public float speed;
    float x = 0.0f, y = 0.0f;
    void Start()
    {
        RWeapon = GameObject.Find("Canvas/RWeapon").GetComponent<RawImage>();
        LWeapon = GameObject.Find("Canvas/LWeapon").GetComponent<RawImage>();
        ability = GameObject.Find("Canvas/Ability/Ability").GetComponent<RawImage>();
        MiniMap = GameObject.Find("Canvas/MiniMap").GetComponent<RawImage>();
        MiniMap.uvRect = new Rect(0, 0, 0.1f, 0.1f);
        RBarrage = GameObject.Find("Canvas/RBarrage").GetComponent<Text>();
        LBarrage = GameObject.Find("Canvas/LBarrage").GetComponent<Text>();
        time = GameObject.Find("Canvas/time").GetComponent<Text>();
        Point = GameObject.Find("Canvas/Point").GetComponent<Text>();
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
                ability.texture = null;
            }
        }
        Rbarrage = RMaxbarrage;
        Lbarrage = LMaxbarrage;
        Lobby = true;
    }
    void Update()
    {
        if (RWeapon.texture == true)
        {
            //残弾
            if (Rbarrage <= RMaxbarrage && Rbarrage > 0)
            {
                if (Input.GetKeyDown(KeyCode.S)) { Rbarrage--; }
            }
            RBarrage.text = "残弾： " + Rbarrage + "/" + RMaxbarrage;
            if (Rbarrage == 0)
            {
                Rweaponslider.value += 0.5f * Time.deltaTime;
                if (Rweaponslider.value >= 1)
                {
                    Rbarrage = RMaxbarrage;
                    Rweaponslider.value = 0;
                }
            }
        }
        else
        {
            RBarrage.text = "";
        }
        if (LWeapon.texture == true)
        {
            //残弾
            if (Lbarrage <= LMaxbarrage && Lbarrage > 0)
            {
                if (Input.GetKeyDown(KeyCode.A)) { Lbarrage--; }
            }
            LBarrage.text = "残弾： " + Lbarrage + "/" + LMaxbarrage;
            if (Lbarrage == 0)
            {
                Lweaponslider.value += 0.5f * Time.deltaTime;
                if (Lweaponslider.value >= 1)
                {
                    Lbarrage = LMaxbarrage;
                    Lweaponslider.value = 0;
                }
            }
        }
        else
        {
            LBarrage.text = "";
        }
        //画像
        for (int m = 0; m < 10; m++)
        {
            if (IsGetW[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    RWeaponTrigger = true;
                    if (RWeaponTrigger == true)
                    {
                        RWeapon.texture = DataBase[m].Wimage;
                    }
                }
            }
            if (IsGetW[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    LWeaponTrigger = true;
                    if (LWeaponTrigger == true)
                    {
                        LWeapon.texture = DataBase[m].Wimage;
                    }
                }
            }
            if (IsGetA[m] == true)
            {
                if (Input.GetKeyDown(KeyCode.C))
                {
                    ABILITY = true;
                    if (ABILITY == true)
                    {
                        ability.texture = DataBase[m].Aimage;
                    }
                }
            }
        }
        if(Lobby == false)
        {

            if (min >= 0F && sec >= 0F)
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
                Point.text = "POINT ：　" + point * length;
            }
            else
            {
                time.text = "TIME ：　00:00";
                SceneManager.LoadScene("Result");
            }
        }
        else
        {
            time.text = "";
            Point.text = "";
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
