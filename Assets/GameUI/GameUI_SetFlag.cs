using UnityEngine;

public class GameUI_SetFlag : MonoBehaviour
{
    void Start()
    {
        GameUISystems.target.Lobby = false;
        Destroy(gameObject);
    }
}
