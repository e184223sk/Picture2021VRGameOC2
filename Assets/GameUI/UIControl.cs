using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    RawImage RWeapon;
    RawImage LWeapon;
    RawImage RSWeapon;
    RawImage LSWeapon;
    RawImage ability;
    RawImage MiniMap;
    public Rect uvRect;
    Text time;
    Text Point;
    Text RBarrage;
    Text LBarrage;
    Slider Rweaponslider;
    Slider Lweaponslider; 
    public bool Lobby; 
    public float sec;
    float x = 0.0f, y = 0.0f;
   
     
    public Texture2D fly, jump, speed, power, reload, fireSpeed;
    void Start()
    {
        RWeapon = transform.Find("RWeapon").GetComponent<RawImage>();
        LWeapon = transform.Find("LWeapon").GetComponent<RawImage>();
        RSWeapon = transform.Find("RsWeapon").GetComponent<RawImage>();
        LSWeapon = transform.Find("LsWeapon").GetComponent<RawImage>();
        ability = transform.Find("Ability/Ability").GetComponent<RawImage>();
        MiniMap = transform.Find("MiniMap").GetComponent<RawImage>();
        MiniMap.uvRect = new Rect(0, 0, 0.1f, 0.1f);
        RBarrage = transform.Find("RBarrage").GetComponent<Text>();
        LBarrage = transform.Find("LBarrage").GetComponent<Text>();
        time = transform.Find("time").GetComponent<Text>();
        Point = transform.Find("Point").GetComponent<Text>();
        sec = 300F;
        Lobby = true;
    }
    void Update()
    {
        if (Lobby)
        {
            //アビリティアイコン--------------------------
            if (Ability._FlyEnable) ability.texture = fly;
            else if (Ability._JumpUPEnable) ability.texture = jump;
            else if (Ability._SpeedUPEnable) ability.texture = speed;
            else if (RigidpowerUp.Enable_) ability.texture = power;
            else if (GunBehavior.IntervalUp__ENABLE) ability.texture = fireSpeed;
            else ability.texture = reload;

            //Map--------------------------------------
        } 


        //時間情報・得点  -------------------------------------------------------------
        if (!Lobby)
        {
            sec -= Time.deltaTime;
            if (sec <= 0F)
            {
                sec = 0;
                SceneManager.LoadScene("Result");
            }
            time.text = "TIME ：　" + ((int)sec) / 60 + ":" + ((int)sec) % 60;
            Point.text = "POINT ：　" + (int)BreakData.BreakingPercentage;
        }
        else
        {
            time.text = "";
            Point.text = "";
        }

        
        var LM = ChangeWeapon.LeftNum == 0 ? ChangeWeapon.GetLeft0 : ChangeWeapon.GetLeft1;
        var LS = ChangeWeapon.LeftNum == 0 ? ChangeWeapon.GetLeft1 : ChangeWeapon.GetLeft0;
        var RM = ChangeWeapon.RightNum == 0 ? ChangeWeapon.GetRight0 : ChangeWeapon.GetRight1;
        var RS = ChangeWeapon.RightNum == 0 ? ChangeWeapon.GetRight1 : ChangeWeapon.GetRight0;
        var LB = LM.GetComponent<WeaponBehavior>();
        var LsB = LS.GetComponent<WeaponBehavior>();
        var RB = RM.GetComponent<WeaponBehavior>();
        var RsB = RS.GetComponent<WeaponBehavior>();
        if (LB != null) LWeapon.texture = LB.WeaponTexture;
        if (LsB != null) LSWeapon.texture = LsB.WeaponTexture;
        if (RB != null) RWeapon.texture = RB.WeaponTexture;
        if (RsB != null) RSWeapon.texture = RsB.WeaponTexture;

        LWeapon.color  = LWeapon.texture != null ? Color.white : Color.black;
        LSWeapon.color = LSWeapon.texture != null ? Color.white : Color.black;
        RWeapon.color  = RWeapon.texture != null ? Color.white : Color.black;
        RSWeapon.color = RSWeapon.texture != null ? Color.white : Color.black; 
        Lweaponslider.value = !LB.IsGUN() ? LB.ReloadingP() : 1f;
        Rweaponslider.value = !RB.IsGUN() ? RB.ReloadingP() : 1f;
        //弾数
        LBarrage.text = LB.IsGUN() ? (LB.NowBullet() + "/" + LB.MaxBullet()) : "";
        RBarrage.text = RB.IsGUN() ? (RB.NowBullet() + "/" + RB.MaxBullet()) : "";

        //--------------------------
        //MAP-----------------------
        //--------------------------
        if (Lobby)
        { }
        else
        {

        }
    }
}

[System.Serializable]
public class Data
{
    public Texture2D Wimage;
    public Texture2D Aimage;
}

//AbilityTexture