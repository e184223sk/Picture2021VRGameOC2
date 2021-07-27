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

    public static void Destroy()
    {
        Destroy(me.player);
        Destroy(me.ui);
        Destroy(me.gameObject);
    }
}
