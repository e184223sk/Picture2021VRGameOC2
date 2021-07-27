using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    static DontDestroyObject me;
    public GameObject player, ui;

    void Start()
    {
        me = this;
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(ui);
    }

    public void Destroy()
    {
        Destroy(player);
        Destroy(ui);
        Destroy(gameObject);
    }
}
