using UnityEngine;

public class HW_LSETsys : MonoBehaviour
{
    void Start()
    {
        var vive = GameObject.Find("[HardWare - System]").GetComponent<ViveSystem>();
        vive.COM = 1;
        vive.init();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }
}