using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_B : MonoBehaviour
{
    float xx;
    public float power;
    Rigidbody r;
    Vector3 startDir;

    void Start()
    {
        r = GetComponent<Rigidbody>();
        Destroy(gameObject, 4);
        startDir = transform.up;
    }

    void Update()
    {
        xx += Time.deltaTime;
        r.AddForce(startDir * power, ForceMode.Acceleration);
    }
   

    void OnCollisionStay(Collision collision)
    {
        if (xx > 0.1f)
        {    
            Instantiate(Resources.Load("Weapon/Bomb"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}