using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG7_bulletEnableCtrl : MonoBehaviour
{
    public GameObject SwitchingCG;
    GunBehavior gb;

    void Start()
    {
        Debug.Log("aaaxxx:" + name);
        gb = GetComponent<GunBehavior>();
    }
    
    void Update()
    {
        SwitchingCG.active = gb.magazine.Now > 0;
    }
}
