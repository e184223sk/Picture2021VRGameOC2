using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float power; 
    Rigidbody r;
    Vector3 startDir;
    void Start()
    {
        r = GetComponent<Rigidbody>();
        Destroy(gameObject, 4);
        startDir = transform.up;
    }

    void Update() => r.AddForce(startDir * power, ForceMode.Acceleration);
}
