using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_B : MonoBehaviour
{
    float xx;
    public float power, hover;
    Rigidbody r;
    Vector3 startDir;
    float i;

    void Update()
    {
        i += Time.deltaTime;
        if (r == null)
        {
            r = GetComponent<Rigidbody>();
            Destroy(gameObject, 4);
            startDir = transform.up;
        }
        if (i < 3 && i > 0.2f)
        {
            r.AddForce(Vector3.up * Time.deltaTime * hover, ForceMode.Acceleration);
            r.AddTorque(Vector3.forward / 100 * Time.deltaTime * hover,ForceMode.Acceleration);
        }
        xx += Time.deltaTime;
        r.AddForce(startDir * power * Time.deltaTime, ForceMode.Acceleration);
    }
   

    void OnCollisionStay(Collision collision)
    {
        if (xx > 0.1f)
        {    
            Instantiate(Resources.Load("Bomb"), transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}