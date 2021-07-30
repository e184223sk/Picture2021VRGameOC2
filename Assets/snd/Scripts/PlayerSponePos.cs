using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSponePos : MonoBehaviour
{
    public Vector3 SponePosition = new Vector3(125, 111, 160);
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.Find("Player").transform.position = SponePosition;
    }

}
