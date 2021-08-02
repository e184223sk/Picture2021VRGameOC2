using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vive_LF : MonoBehaviour
{
    public bool f1, f2, e1, e2;
    public float cnt;
    public float Power;

    void Update()
    {
        cnt += Time.deltaTime;
        if (!f1 && cnt > 0.00f) { ViveSystem.LeftAnkle += Power; f1 = true; }
        if (!f2 && cnt > 0.08f) { ViveSystem.LeftKnee += Power; f2 = true; }
        if (!e1 && cnt > 0.18f) { ViveSystem.LeftAnkle -= Power; e1 = true; }
        if (!e2 && cnt > 0.26f) { ViveSystem.LeftKnee -= Power; e2 = true; Destroy(this); }
    }
}
