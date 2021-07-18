using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test001 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon.SetLeft0(Instantiate(Resources.Load("M4")) as GameObject);
        ChangeWeapon.SetLeft1(Instantiate(Resources.Load("BeamSaber")) as GameObject);
        ChangeWeapon.SetRight0(Instantiate(Resources.Load("M4")) as GameObject);
        ChangeWeapon.SetRight1(Instantiate(Resources.Load("BeamSaber")) as GameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (VRInput.A) ChangeWeapon.ChangeL();
        if (VRInput.Y) ChangeWeapon.ChangeR();
    }
}
