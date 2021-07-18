using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBehavior : MonoBehaviour
{
    public string WeaponName;
    public string WeaponTexture;
    public virtual int NowBullet() => -1;
    public virtual int MaxBullet() => -1;
    public virtual bool IsGUN() => false;
    public virtual bool IsReloading() => false;
    public virtual float ReloadingP() => 0.0f;
}
