using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]// SendMessageでエラーが出ないように
public class AutoGetCompornennt : MonoBehaviour
{
    GameObject[] game;

    public void DataSet_GameObject()
    {
        game = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        //Debug.Log(game);
        //受け取った配列のそれぞれの名前を出力
        foreach (var item in game)
        {
            if(item.transform.root == transform)
            {
                Debug.Log(item.gameObject.name);
            }
            else
            {
                //Debug.Log("???");
            }
            
        }
    }

    public void DataSet_Rigidbody()
    {
        //Rigidbody rb = game.GetComponent<Rigidbody>();
        Debug.Log("??");
    }
}