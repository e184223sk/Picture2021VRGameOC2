using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardWareSettings : MonoBehaviour
{ 
    public static int phase;
    public const int phaseLast = 6;
    public GameObject HWS;
    public HardWareSetScene_SetCom VBCOM;
    public HardWareSetScene_SetCom WSCOM;
    public HardWareSetScene_Console _CONSOLE;
    float c;
    // Start is called before the first frame update
    void Start()
    {
        HWS = GameObject.Find("[HardWare - System]");
        phase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                if (VBCOM.IsGO)
                {
                    VBCOM.transform.gameObject.active = false;
                    HWS.GetComponent<ViveSystem>().COM = VBCOM.PORTs;
                   string d = HWS.GetComponent<ViveSystem>().init();
                    if (d == "")
                    { 
                        _CONSOLE.Write("LOG:接続しました");
                        phase = 1;
                    }
                    else
                    {
                        _CONSOLE.Write("ERROR:" + d);
                    }
                }
                else if (VBCOM.IsSkip)
                {
                    VBCOM.transform.gameObject.active = false;
                    WSCOM.transform.gameObject.active = true;
                    phase = 2;
                }
                break;

            case 1: break;

            case 2:
                if (WSCOM.IsGO)
                {
                    WSCOM.transform.gameObject.active = false;
                    HWS.GetComponent<WindSystem>().COM = WSCOM.PORTs;
                    string d = HWS.GetComponent<WindSystem>().init();
                    if (d == "")
                    {
                        _CONSOLE.Write("LOG:接続しました");
                        phase = 3;
                    }
                    else
                    {
                        _CONSOLE.Write("ERROR:" + d);
                    }
                }
                else if (WSCOM.IsSkip)
                {
                    WSCOM.transform.gameObject.active = false;
                    phase = 4;
                }
                break;
            case 3: break;
            case 4: break;
            case 5:
                
                break;

            default:
                c += Time.deltaTime;
                if (c > 1) UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
                    break;
        }
         
    }
}

//VB:Com
//VB:CodeCheck
//Ws:Com
//Ws:CodeCheck
//Sound:
//Go!!

//UI