using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test001 : MonoBehaviour
{
    bool flag;

    private void Start()
    {
        Debug.Log("L:" + VRInput.LHandPos.transform.name);
        Debug.Log("R:" + VRInput.RHandPos.transform.name);
        Debug.Log("aaa0");
        ChangeWeapon.SetLeft0(Instantiate(Resources.Load("Weapon/M4")) as GameObject);
        ChangeWeapon.SetLeft1(Instantiate(Resources.Load("Weapon/BeamSaber")) as GameObject);
        ChangeWeapon.SetRight0(Instantiate(Resources.Load("Weapon/M4")) as GameObject);
        ChangeWeapon.SetRight1(Instantiate(Resources.Load("Weapon/BeamSaber")) as GameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if (!flag)
        {
           
            flag = true;
        }
        if (VRInput.RStickPush) ChangeWeapon.ChangeR();
        if (VRInput.LStickPush) ChangeWeapon.ChangeL();
    }
}
