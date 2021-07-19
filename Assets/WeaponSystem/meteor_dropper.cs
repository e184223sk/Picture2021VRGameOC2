using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor_dropper : MonoBehaviour
{
    public float SpawnArea;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Vector3 e = transform.position + transform.forward * 10 + new Vector3(Mathf.Cos(Random.Range(-1.0f, 1.0f) * Mathf.PI), 0, Mathf.Sin(Random.Range(-1.0f, 1.0f) * Mathf.PI)) * SpawnArea;
                Instantiate((Resources.Load("Weapon/Meteor")) as GameObject, e, Quaternion.Euler(10, 10, 10));
                timer = 0.1f;
            }
        }
    }
}
