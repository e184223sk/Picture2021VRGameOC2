using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayer : MonoBehaviour
{

    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _player.GetComponent<Rigidbody>().useGravity = false;
        _player.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        _player.transform.position = new Vector3(238, 149, 500);
    }
}
