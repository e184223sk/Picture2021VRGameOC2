using UnityEngine;

public class RejectBulletController : MonoBehaviour
{
    [SerializeField, Range(1,10)]
    float lifetime = 6;
    float v;
    Vector3 moveXZ;
    public float bounce,raising,Gravity;
    public Vector3 rotationPower;
    const float PI = 2 * Mathf.PI;
    Vector3 direction;
     
    void Start()
    { 
        var x = Random.Range(0f, 2f);
        moveXZ = new Vector3 ( Mathf.Sin(x * PI), Mathf.Sin(x * PI), Mathf.Cos(x * PI));
        transform.Rotate(Random.Range(-45,45), Random.Range(-45, 45), Random.Range(-45,45));
        direction = transform.forward;
        Destroy(gameObject, lifetime);
    }
     

    public void Update()
    {  
        v += Time.deltaTime;
        float s = Mathf.Pow(Mathf.Cos((v > 0.5f ? 0 : v) / 2), 2);
        transform.rotation *= Quaternion.Euler(rotationPower * 180 * Time.deltaTime);
        transform.position += Time.deltaTime * ((Vector3.Scale(direction, moveXZ) * bounce * s) + (Vector3.down * (Gravity - s * raising)));
    } 

}
