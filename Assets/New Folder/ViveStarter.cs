using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveStarter : MonoBehaviour
{
    ViveSystem v;
    void Start()
    {
        v = GetComponent<ViveSystem>();
        v.COM = 3;
        string s = v.init();
        Debug.LogError(s);
    }

}
