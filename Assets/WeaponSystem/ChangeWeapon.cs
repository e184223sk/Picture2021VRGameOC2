using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon
{
    public static void SetLeft0(GameObject g) => Weapon[0, 0] = g;
    public static void SetLeft1(GameObject g) => Weapon[0, 0] = g;
    public static void SetRight0(GameObject g) => Weapon[0, 0] = g;
    public static void SetRight1(GameObject g) => Weapon[0, 0] = g;
    public static int LeftNum  { get => L ? 0 : 1; }
    public static int RightNum { get => R ? 0 : 1; }
    public static void ChangeL() { L = !L; UPDATE(); }
    public static void ChangeR() { R = !R; UPDATE(); }
    public static GameObject GetLeft0 => Weapon[0, 0];
    public static GameObject GetLeft1 => Weapon[0, 1];
    public static GameObject GetRight0 => Weapon[1, 0];
    public static GameObject GetRight1 => Weapon[1, 1];


    static GameObject[,] Weapon = new GameObject[2, 2];
    static bool L, R;
    static void UPDATE()
    {
        Weapon[0, 0].active =  L;
        Weapon[0, 1].active = !L;
        Weapon[1, 0].active =  R;
        Weapon[1, 1].active = !R;
    } 
}
