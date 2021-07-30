using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("xxxxxxxx")]
    private void Method()
    {
        for (int v = 0; v < 100; v++)
        {

            transform.Find("Ring (" + v + ")").transform.localPosition = new Vector3 (0,-0.01813f +  (-0.2275999f + 0.01813f)/100 * v,0);
            transform.Find("Ring (" + v + ")").GetComponent<HingeJoint>().connectedBody =
                v > 0 ? transform.Find("Ring (" +(v+1) + ")").GetComponent<Rigidbody>() : transform.Find("Glip/glip").GetComponent<Rigidbody>();

        }
    }
}
