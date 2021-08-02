using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveSetter : MonoBehaviour
{
    public static ViveSetter me;
        // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        me = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) LH();
        if (Input.GetKeyDown(KeyCode.S)) RH();
        if (Input.GetKeyDown(KeyCode.Z)) LF();
        if (Input.GetKeyDown(KeyCode.X)) RF();
    }


    public static void LH() => me.gameObject.AddComponent<Vive_LH>().Power = 0.4f;
    public static void RH() => me.gameObject.AddComponent<Vive_RH>().Power = 0.4f;
    public static void LF() => me.gameObject.AddComponent<Vive_LF>().Power = 0.4f;
    public static void RF() => me.gameObject.AddComponent<Vive_RF>().Power = 0.4f;
}
