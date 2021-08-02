using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        PlayerCtrler._IsGround = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        ViveSetter.LF();
        ViveSetter.RF();
        Debug.Log("aaaa");
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerCtrler._IsGround = false;
    }
    
}
