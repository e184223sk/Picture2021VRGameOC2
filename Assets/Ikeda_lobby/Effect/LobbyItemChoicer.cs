using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyItemChoicer : MonoBehaviour
{ 
    public ItemType type;
    GameObject EffectRoot;
    public bool hit;
    public enum ItemType { Weapon, Ability }

    void Start()
    {
        EffectRoot = transform.Find("Effect").gameObject; 
    }
    
    void Update()
    {
        EffectRoot.active  = hit;
        if (!hit)
        {

        }
        else
        { 
            if (type == ItemType.Ability)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    //キー入力でセット
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A)) { /*武器Lセット*/ }
                if (Input.GetKeyDown(KeyCode.S)) { /*武器Rセット*/ }
            }
        }
    }

    void OnTriggerExit(Collider o) {   if (o.GetComponent<Dammy_PLayer>() != null) hit = false; }    
    void OnTriggerStay(Collider o) {  if (o.GetComponent<Dammy_PLayer>() != null) hit = true; }
}

