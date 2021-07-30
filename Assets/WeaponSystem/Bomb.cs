using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject.transform.root.gameObject, 3);
        Destroy(this, 1.7f);
    }
    void Update() => transform.localScale += Vector3.one *5600* Time.deltaTime;
}
