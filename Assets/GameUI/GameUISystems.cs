using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUISystems : MonoBehaviour
{
    public static UIControl target;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<UIControl>();
    }
      

    // Update is called once per frame
    void Update()
    {
        
    }
}
