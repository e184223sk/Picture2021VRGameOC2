using UnityEngine;

public class Lobby_ResetPanelArea : MonoBehaviour
{
    public void OnTriggerEnter(Collider o)
    { 
        if (o.transform.GetComponent<Dammy_PLayer>() != null)
            Reset.me.reborn();
    } 
}
