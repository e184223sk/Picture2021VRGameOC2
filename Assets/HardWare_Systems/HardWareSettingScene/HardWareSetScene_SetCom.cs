using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardWareSetScene_SetCom : MonoBehaviour
{
    Slider slider;
    Text text;
    public bool IsGO;
    public bool IsSkip;
    public int PORTs;
    // Start is called before the first frame update
    void Start()
    {
        slider = transform.Find("COMs").GetComponent<Slider>();
        text = transform.Find("COMs/Data").GetComponent<Text>();
        transform.Find("GO").GetComponent<Button>().onClick.AddListener(delegate () { IsGO = true; });
        transform.Find("Skip").GetComponent<Button>().onClick.AddListener(delegate () { IsSkip = true; });
    }
    
    void Update()
    {
        PORTs = (int)slider.value;
        text.text = "[COM" + PORTs + "]";
    }
}
