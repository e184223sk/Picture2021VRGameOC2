using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUISystems : MonoBehaviour
{
    public static UIControl target;

    void Start()
    {
        target = GetComponent<UIControl>();
    }
     
}
