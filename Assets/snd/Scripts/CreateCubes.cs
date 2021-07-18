using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class CreateCubes : MonoBehaviour
{

    [MenuItem("Window/CreateCube")]
    public static void Create()
    {
        GameObject parent = new GameObject();
        for(int i =0;i < 5; i++)
        {
            for (int j =0; j < 5; j++)
            {
                for(int k = 0;k < 5; k++)
                {
                    
                    GameObject tmp = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    tmp.transform.position = new Vector3((float)(i + 0.25), (float)(j + 0.25), (float)(k + 0.25));
                    tmp.transform.parent = parent.transform;
                }
            }
        }
    }
}
