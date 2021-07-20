using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Monitor : MonoBehaviour
{
    bool k;
    public VideoPlayer Video;
    // Start is called before the first frame update
    void Start()
    {
        Video.Play();
        Video.isLooping = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!k)
        {
            Video.Pause();
            k = true;
        }
    }

    //再生
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("反応したよ");
        if(other.gameObject.GetComponent<Player>() != null)
        {
            Video.Play();
        }
    }

    //停止
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            Video.Pause();
        }
    }
}
