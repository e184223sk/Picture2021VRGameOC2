using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPower : WeaponBehavior
{
    public float powerSens = 10;
    ParticleSystem p;
    float xx;
    public Vector3 w, w2;
    public float ww;
     
    // Start is called before the first frame update
    void Start()
    {
        p = transform.Find("c/BeamSaber/Particle System").GetComponent<ParticleSystem>();
        xx = p.startSpeed;
    }
    Vector3 e,e2;
    // Update is called once per frame
    void Update()
    {
        w = p.transform.position- e ;
        w2 = VRInput.BodyCenterPos.position - e2;
        w -= w2;
        ww = Mathf.Abs(w.x) + Mathf.Abs(w.y) + Mathf.Abs(w.z);
        p.startSpeed = ww * ww * powerSens + xx;
        e = p.transform.position;
        e2 = VRInput.BodyCenterPos.position;
    }
}
