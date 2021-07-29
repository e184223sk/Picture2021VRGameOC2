using UnityEngine;

public class Bomb : MonoBehaviour
{
    void Start() => Destroy(gameObject.transform.root.gameObject, 2);
    void Update() => transform.localScale += Vector3.one * 17* Time.deltaTime;
}
