using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSystem : SerialSystems
{
    public static float LeftDown  { get => Power[0]; set => Power[0] = set(value); }
    public static float LeftUp    { get => Power[1]; set => Power[1] = set(value); }
    public static float RightDown { get => Power[2]; set => Power[2] = set(value); }
    public static float RightUp   { get => Power[3]; set => Power[3] = set(value); }
    public static float BackDown  { get => Power[4]; set => Power[4] = set(value); }
    public static float BackUp    { get => Power[5]; set => Power[5] = set(value); }

    static float set(float raw) => raw > 1 ? 1 : (raw < 0 ? 0 : raw);
    static float[] Power = new float[6];
    static int f = -1;

    void Set(int v) => WriteLine("abcdefg"[v] + "0123456789ABCDEFGHIJKLMNOPQRSTUV".Substring((int)(Power[v] * 31), 1));

    public void Update()
    {
        if (!IsSetting) return;   
        f++;
        if (f == 3) f = 0;
        Set(f);
        Set(f + 3);
    }
}
