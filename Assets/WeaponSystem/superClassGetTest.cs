using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superClassGetTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<WeaponBehavior>().WeaponName = "aaaaa";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
