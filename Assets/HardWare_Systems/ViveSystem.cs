using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 振動デバイス「Vive Boy」制御用のクラス
/// </summary>
public  class ViveSystem : SerialSystems
{

    /// <summary> 頭部の振動の強さ </summary>
    public static float Head       { get => Power[0]; set => Power[0] = set(value); }

    /// <summary> 胴部の振動の強さ </summary>
    public static float Body       { get => Power[1]; set => Power[1] = set(value); }

    /// <summary> 左肘の振動の強さ </summary>
    public static float LeftElbow  { get => Power[2]; set => Power[2] = set(value); }

    /// <summary> 右肘の振動の強さ </summary>
    public static float RightElbow { get => Power[3]; set => Power[3] = set(value); }

    /// <summary> 左手首の振動の強さ </summary>
    public static float LeftWrist  { get => Power[4]; set => Power[4] = set(value); }

    /// <summary> 右手首の振動の強さ </summary>
    public static float RightWrist { get => Power[5]; set => Power[5] = set(value); }

    /// <summary> 左ひざの振動の強さ </summary>
    public static float LeftKnee   { get => Power[6]; set => Power[6] = set(value); }

    /// <summary> 右ひざの振動の強さ </summary>
    public static float RightKnee  { get => Power[7]; set => Power[7] = set(value); }

    /// <summary> 左足首の振動の強さ </summary>
    public static float LeftAnkle  { get => Power[8]; set => Power[8] = set(value); }

    /// <summary> 右足首の振動の強さ </summary>
    public static float RightAnkle { get => Power[9]; set => Power[9] = set(value); }


    static float set(float raw) => raw > 1 ? 1 : (raw < 0 ? 0 : raw);
    static float[] Power = new float[10];

    public override void DISPOSE()
    {
        ViveSystem.Body = 0;
        ViveSystem.Head = 0;
        ViveSystem.LeftElbow = 0;
        ViveSystem.RightElbow = 0;
        ViveSystem.LeftWrist = 0;
        ViveSystem.RightWrist = 0;
        ViveSystem.LeftKnee = 0;
        ViveSystem.RightKnee = 0;
        ViveSystem.LeftAnkle = 0;
        ViveSystem.RightAnkle = 0;

    }

    public void Update()
    {
        if (!IsSetting) return;
 
        for (int y = 0; y < 10; y++)
        {
            WriteLine("abcdefghij"[y] + "0123456789ABCDEFGHIJKLMNOPQRSTUV".Substring((int)(Power[y] * 31), 1));
            for (int x = 0; x < 100; x++) ; //データ処理待ちの為の保険
        }
    }
}
 