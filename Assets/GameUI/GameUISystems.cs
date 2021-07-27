using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUISystems : MonoBehaviour
{
    public static UIControl target;

    void Start()
    {
        target = GetComponent<UIControl>();
    }
    

    void Update()
    {
        
        if (target.Lobby)
        {
            //アビリティアイコン--------------------------
            if (Ability._FlyEnable) { }
            else if (Ability._FlyEnable) { }
            else if (Ability._FlyEnable) { }
            else if (Ability._FlyEnable) { }
            else if (Ability._FlyEnable) { }
            else { }

            //Map--------------------------------------
        }

        else
        {
            //武器-----------------------------------
            
        //武器アイコン
            //武器弾数
            //武器リロードバー
            //Map-------------------------------------
        }

    }
}
