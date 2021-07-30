using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public float powerSens = 10, SPEED;
    ParticleSystem p;
    float xx, data;
    public Vector3 w, w2;
    public float ww;
    public float dataThreshold;
    BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        p = transform.Find("Particle System").GetComponent<ParticleSystem>();
        xx = p.startSpeed;
    }
    Vector3 e, e2;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * Time.deltaTime * SPEED,Space.Self);
        bc.size = Vector3.one;
        w = p.transform.position - e;
        w2 = VRInput.BodyCenterPos.position - e2;
        w -= w2;
        ww = Mathf.Abs(w.x) + Mathf.Abs(w.y) + Mathf.Abs(w.z);
        data = ww * ww * powerSens + xx;
        e = p.transform.position;
        e2 = VRInput.BodyCenterPos.position;
    }

    private void OnCollisionStay(Collision c)
    { 
        if (!p.isPlaying && c.transform.root != transform.root && data > dataThreshold)
            bc.size = Vector3.one + Vector3.forward * 2;

    }
}
