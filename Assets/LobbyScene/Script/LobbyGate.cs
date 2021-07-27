using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyGate : MonoBehaviour
{
    public float time = 0.0f;
   
    //入口の処理
    void OnTriggerStay(Collider other)
    {
        Debug.Log("反応した");
        if (other.gameObject.GetComponent<PlayerCtrler>() != null)
        { 
            time += Time.deltaTime;
            if (time >= 4.0f)
            { 
                SceneManager.LoadScene("Game");
            }
        }
    }

    //出口の処理
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCtrler>() != null)
        {
            time = 0.0f;
        }
    }
}
