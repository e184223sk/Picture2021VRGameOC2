using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordVive : WeaponBehavior
{

    private void OnCollisionEnter(Collision collision)
    {
        if (side == HandSide.LEFT) ViveSetter.LH();
        if (side == HandSide.RIGHT) ViveSetter.RH();
    }

}
