using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidpowerUp : MonoBehaviour
{
    const float PowerUps = 4;
    public static bool Enable_;
    public bool Particles;
    // Start is called before the first frame update
    void Start()
    {
        if (Enable_) 
        {
            if (Particles)
            {
                var c = GetComponent<ParticleSystem>().collision;
                c.colliderForce *= PowerUps;
            }
            else GetComponent<Rigidbody>().mass *= PowerUps;
        }
        Destroy(this);
    }
    
}
