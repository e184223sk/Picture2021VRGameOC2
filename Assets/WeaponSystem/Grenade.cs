using UnityEngine;

public class Grenade : MonoBehaviour
{
    CapsuleCollider cc;
    void Start()
    {
        Invoke("_Bomb_", 5);
        cc = GetComponent<CapsuleCollider>();
        cc.enabled = false;
        Invoke("CC", 0.6f);
    }

    void CC() => cc.enabled = true;
    void _Bomb_()
    {
        Instantiate(Resources.Load("Bomb"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
