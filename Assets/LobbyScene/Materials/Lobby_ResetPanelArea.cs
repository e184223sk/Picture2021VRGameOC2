using UnityEngine;

public class Lobby_ResetPanelArea : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Dammy_PLayer>() != null)
            GameObject.Find("reset").GetComponent<Reset>().reborn();
    }
}
