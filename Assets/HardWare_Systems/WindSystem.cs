using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSystem : SerialSystems
{
    /// <summary>
    /// {上, 正面上, 正面下, 後方左上, 後方左下, 後方右上, 後方右下,}
    /// </summary>
    public float[] Power = new float[7];
    const string C32 = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
    int f;

    void Start()
    {
        f = -1;
    }

    void Set(int v)
    {
        if(0<v && v < 6)
            WriteLine("abcdefg"[v] + C32.Substring((int)(Power[0] * 31), 1));
    }
    

    public void Update_()
    {
        if (!IsSetting) return;

        //データの上限下限の補正--------------------------------------------
        for (int y = 0; y < 7; y++)
            Power[y] = Power[y] > 1 ? 1 : (Power[y] < 0 ? 0 : Power[y]);

        //4フレームに分散して送信------------------------------------------
        f++;
        if (++f == 4) f = 0;
        switch (f)
        {
            case 0: Set(0); Set(1); break;
            case 1: Set(2); Set(3); break;
            case 2: Set(4); Set(5); break;
            case 3: Set(6); break; 
        }
        
    }
}
