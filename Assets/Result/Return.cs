using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour
{
    
    void Start()
    {
        
    }

    //ロビー画面へ遷移
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ロビー画面へ行けた");
            SceneManager.LoadScene("Lobby");
        }   
    }
}
