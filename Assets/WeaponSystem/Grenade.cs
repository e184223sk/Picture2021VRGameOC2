using UnityEngine;

public class Grenade : MonoBehaviour
{
    void Start() => Invoke("_Bomb_", 5);

    void _Bomb_()
    {
        Instantiate(Resources.Load("Bomb"), transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
