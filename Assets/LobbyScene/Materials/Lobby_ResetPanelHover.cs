using UnityEngine;

public class Lobby_ResetPanelHover : MonoBehaviour
{
    Vector3 d;
    float e;
    public float sensivirity;
    public float speed;
    void Start() => d = transform.position;
    void Update()
    {
        e += Time.deltaTime * speed;
        transform.position = d + Vector3.up * Mathf.Sin(e) * sensivirity;
    }
}
