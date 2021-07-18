using UnityEngine;

public class DeleteObjectTimer : MonoBehaviour
{
    [Range(0.01f, 10)]
    public float timer = 1;
    void Start() => Destroy(gameObject, timer);
}
