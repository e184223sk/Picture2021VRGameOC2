using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_VB : MonoBehaviour
{
    [Range(0, 1)]
    public float Head, shoulderL, shoulderR, armL, armR, kneeL, kneeR, footL, footR, Body;

    ViveSystem v;
    // Start is called before the first frame update
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
        ViveSystem.Body = Body;
        ViveSystem.Head = Head;
        ViveSystem.LeftElbow  = shoulderL;
        ViveSystem.RightElbow = shoulderR;
        ViveSystem.LeftWrist  = armL;
        ViveSystem.RightWrist = armR;
        ViveSystem.LeftKnee = kneeL;
        ViveSystem.RightKnee = kneeR;
        ViveSystem.LeftAnkle = footL;
        ViveSystem.RightAnkle = footR;  
    }

}
