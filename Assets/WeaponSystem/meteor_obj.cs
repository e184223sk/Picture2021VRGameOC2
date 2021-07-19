using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_obj : MonoBehaviour
{
    float timer = 4;
    Rigidbody r;
    public float Power = 100;
    public ForceMode mode = ForceMode.Force; 
    void Start()
    {
        r = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject,6);
            Destroy(this);
        }
        r.AddRelativeForce(Vector3.up * -Power * Time.deltaTime, mode);
    }
}
