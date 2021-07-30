using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyItemChoicer : MonoBehaviour
{ 
    public ItemType type;
    GameObject EffectRoot;
    public bool hit;
    public enum ItemType { Weapon, Ability }
    public string WeaponName;

    public enum AbilityType { SpeedUp,Hover, ReloadUp, PowerUp, Jump, FireInterval };
    public AbilityType abilityType;
    public bool cooldown;
    public float cooldownCnt;
    
    void Start()
    {
        ResetAbility();
        EffectRoot = transform.Find("Effect").gameObject; 
    }
    
    void Update()
    {
        EffectRoot.active  = true;
        if (!hit)
        {

        }
        else if(cooldown)
        {
            cooldownCnt -= Time.deltaTime;
            if (cooldownCnt <= 0)
            {
                cooldown = false;
                cooldownCnt = 0;
            }
        }
        else
        { 
            if (type == ItemType.Ability)
            {
                if (Input.GetKeyDown(KeyCode.S) || VRInput.A && !Ability._IsUsing)
                {
                    ResetAbility();
                    CoolDownStart();
                    switch (abilityType)
                    {
                        case AbilityType.Hover: Ability._FlyEnable = true; Debug.Log("ジェットパック");  break;
                        case AbilityType.Jump: Ability._JumpUPEnable = true; Debug.Log("ジャンプ力アップ"); break;
                        case AbilityType.SpeedUp: Ability._SpeedUPEnable = true; Debug.Log("スピードアップ"); break;
                        case AbilityType.PowerUp: RigidpowerUp.Enable_ = true; Debug.Log("パワー！！"); break;
                        case AbilityType.ReloadUp: GunBehavior.ReloadTimeUP__ENABLE = true; Debug.Log("ファストリロード"); break;
                        case AbilityType.FireInterval: GunBehavior.IntervalUp__ENABLE = true; Debug.Log("ラピッドファイア"); break;
                        default: Debug.Log("存在しないアビリティです"); break;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A) || VRInput.X )
                {
                    CoolDownStart();
                    if (ChangeWeapon.LeftNum == 0)
                        ChangeWeapon.SetLeft0(Instantiate(Resources.Load("Weapon/" + WeaponName)) as GameObject);
                    else
                        ChangeWeapon.SetLeft1(Instantiate(Resources.Load("Weapon/" + WeaponName)) as GameObject);
                }
                if (Input.GetKeyDown(KeyCode.S) || VRInput.A)
                { 
                    CoolDownStart();
                    if (ChangeWeapon.RightNum == 0)
                        ChangeWeapon.SetRight0(Instantiate(Resources.Load("Weapon/" + WeaponName)) as GameObject);
                    else
                        ChangeWeapon.SetRight1(Instantiate(Resources.Load("Weapon/" + WeaponName)) as GameObject); 
                }
            }
        }
    }

    void CoolDownStart()
    {
        cooldownCnt = 4;
        cooldown = true;
    }

    void OnTriggerExit(Collider o) {   if (o.GetComponent<PlayerCtrler>() != null) hit = false; }    
    void OnTriggerStay(Collider o) {  if (o.GetComponent<PlayerCtrler>() != null) hit = true; }

    void ResetAbility()
    {
        Ability._FlyEnable = false;
        Ability._JumpUPEnable = false;
        Ability._SpeedUPEnable = false;
        GunBehavior.IntervalUp__ENABLE = false;
        GunBehavior.ReloadTimeUP__ENABLE = false;
        RigidpowerUp.Enable_ = false;
    }
    
}

