﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{ 
    //ロビー画面へ遷移
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DontDestroyObject.Destroy();
            Debug.Log("ロビー画面へ行けた");
            SceneManager.LoadScene("Lobby");
        }   
    }
}
