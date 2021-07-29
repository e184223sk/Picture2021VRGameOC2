using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    static DontDestroyObject me;
    public GameObject player, ui;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        me = this;
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(ui);
    }

    public static void _Destroy()
    {
        Destroy(me.player);
        Destroy(me.ui);
        Destroy(me.gameObject);
    }
}
