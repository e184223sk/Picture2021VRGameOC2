using UnityEngine;
using UnityEngine.UI;

public class HardWareSetScene_TaskList : MonoBehaviour
{
    int Lp = -1;
    public Color NOW, YET, CLEAR;

    void Update()
    {
        if (Lp == HardWareSettings.phase) return;
        for (int v = 0; v < HardWareSettings.phaseLast; v++)
            transform.Find("Text (" + v + ")").GetComponent<Text>().color = v > HardWareSettings.phase ? YET : (v < HardWareSettings.phase ? CLEAR : NOW);
        Lp = HardWareSettings.phase;
    }
}
