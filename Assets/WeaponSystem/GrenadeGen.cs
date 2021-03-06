using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeGen : MonoBehaviour
{
    public GameObject CG;
    public float ThrowingThreshold,Power = 1000; 
    Vector3 w, w2, e, e2;
    float ww,v;

    void Start() => v = 5;

    void Update()
    {
        v += Time.deltaTime;
        CG.active = v >= 5;
        if (v < 5) return;
        w2 = VRInput.BodyCenterPos.position - e2;
        w -= w2;
        ww = Mathf.Abs(w.x) + Mathf.Abs(w.y) + Mathf.Abs(w.z);
       
        float data = ww * ww;
        var i = GetComponent<WeaponBehavior>(); 
        if (i.side == WeaponBehavior.HandSide.LEFT ? VRInput.LTrigger : VRInput.RTrigger && data > ThrowingThreshold)
        {
            var x = Instantiate(Resources.Load("Mk2"), transform.position, transform.rotation) as GameObject;
            x.GetComponent<Rigidbody>().AddRelativeForce((i.side == WeaponBehavior.HandSide.LEFT ? VRInput.LHandPos.forward : VRInput.RHandPos.forward) * -1 * Power * data);
            v = 0;
        }
        e2 = VRInput.BodyCenterPos.position;
    }
}

