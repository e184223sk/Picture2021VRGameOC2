using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveSystem : SerialSystems
{

    /// <summary>
    /// 未記入
    /// </summary>
   
    public float[] Power = new float[10];
    const string C32 = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
    int f;

    void Start()
    {
        f = -1;
    }

    void Set(int v)
    {
        if (0 < v && v < 9)
            WriteLine("abcdefg"[v] + C32.Substring((int)(Power[0] * 31), 1));
      
    }


    public void Update_()
    {
        if (!IsSetting) return;

        //データの上限下限の補正--------------------------------------------
        for (int y = 0; y < 10; y++)
            Power[y] = Power[y] > 1 ? 1 : (Power[y] < 0 ? 0 : Power[y]);

        //4フレームに分散して送信------------------------------------------
        f++;
        if (++f == 5) f = 0;
        Set(f);
        Set(f);
        Set(f);
        //0123456789
        //05
        //16
        //27
        //38
        //49

        switch (f)
        {
            case 0: Set(1); break;
            case 1: Set(2); Set(3); break;
            case 2: Set(4); Set(5); break;
            case 3: Set(6); break;
        }

    }
}
 