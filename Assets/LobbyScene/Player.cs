using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //入口の処理
    void OnTriggerStay(Collider other)
    {
        Debug.Log("反応した");
       if(other.gameObject.GetComponent<LobbyGate>() != null)
       {
            Debug.Log("aaa");
            time += Time.deltaTime;
            if (time >= 4.0f)
            {
                Debug.Log("Gameシーンに行けた");
                SceneManager.LoadScene("Game");
            }
       }    
    }

    //出口の処理
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<LobbyGate>() != null)
        {
                time = 0.0f;
        }
    }
}
