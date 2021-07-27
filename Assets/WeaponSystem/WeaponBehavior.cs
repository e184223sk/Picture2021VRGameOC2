using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBehavior : MonoBehaviour
{
    public HandSide side;
    public enum HandSide { LEFT, RIGHT }
    public string WeaponName;
    public Texture2D WeaponTexture;
    public virtual int NowBullet() => -1;
    public virtual int MaxBullet() => -1;
    public virtual bool IsGUN() => false;
    public virtual bool IsReloading() => false;
    public virtual float ReloadingP() => 0.0f;
    public Vector3 L, R;

    public void Awake()
    {
        transform.rotation = Quaternion.Euler(side == HandSide.LEFT ? L : R);
    }
}
