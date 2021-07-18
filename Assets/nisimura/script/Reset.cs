using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{ 
    public static float time = 0;
    GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }

    // Update is called once per frame
    void Update()
    {
        if (BreakManagerInlobby.rBreakobj * 1.0f/BreakManagerInlobby.rTotal > 0.8f)
        {


                    //Debug.Log(item.gameObject + "に破壊処理いれたまるー");
                    //item.gameObject.AddComponent<BreakManager>();
                    time += Time.deltaTime;
                    if (time > 4)
                    {
                        Instantiate(Resources.Load("reset"), new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                        time = 0;
                        Destroy(gameObject);
                    }
                

            

        }
    }
}
