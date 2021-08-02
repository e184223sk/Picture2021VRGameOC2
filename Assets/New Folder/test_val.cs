using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_val : MonoBehaviour
{
    public bool flag,f1,f2,e1,e2;
    public float cnt;
    [Range(0,1)]
    public float _1st, _2nd;
    public float Power;
    ViveSystem v;
    void Start()
    {
        v = GetComponent<ViveSystem>();
        v.COM = 4;
        string s =  v.init();
        Debug.LogError(s);
    }


    // Update is called once per frame
    void Update()
    {
        if (!flag) return;
        cnt+= Time.deltaTime;
        if (!f1 && cnt > 0.00f) { ViveSystem.RightWrist = ViveSystem.RightWrist + Power; Debug.Log("a" + ViveSystem.RightWrist); f1 = true; }
        if (!f2 && cnt > 0.08f) { ViveSystem.RightElbow = ViveSystem.RightElbow + Power; Debug.Log("c" + ViveSystem.RightElbow); f2 = true; }
        if (!e1 && cnt > 0.18f) { ViveSystem.RightWrist = ViveSystem.RightWrist - Power; Debug.Log("b" + ViveSystem.RightWrist); e1 = true; }
        if (!e2 && cnt > 0.26f) { ViveSystem.RightElbow = ViveSystem.RightElbow - Power; Debug.Log("d" + ViveSystem.RightElbow); e2 = true;  Destroy(this); }
        if (cnt > 0.30) { flag = f1 = f2 = e1 = e2 = false; }
    }
}
