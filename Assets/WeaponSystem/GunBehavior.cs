using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GunBehavior : WeaponBehavior
{
    public static bool IntervalUp__ENABLE;
    public static bool ReloadTimeUP__ENABLE; 

    bool FIRE_PRESS { get => (side == HandSide.LEFT ? VRInput.LTriggerPress : VRInput.RTriggerPress)|| Input.GetKey(KeyCode.Y); }
    bool FIRE_DOWN { get => (side == HandSide.LEFT ? VRInput.LTrigger : VRInput.RTrigger) || Input.GetKeyDown(KeyCode.Y); }
    bool RELOAD { get => (side == HandSide.LEFT ? VRInput.Y : VRInput.B) || Input.GetKey(KeyCode.U); }
   
    AudioSource source;
    public AudioClip fireSe, reloadSe;
    public HandSide side;
    public GunType gunType;
    [Range(0.03f, 1f)]
    public float FullAutoFireInterval = 0.4f;
    float FireCnt;
    [Header("Reload Info"), Space(14)]
    public bool AutoReload;
    [SerializeField,Range(1, 10)]
    float ReloadCnt;
    [Range(1,10)]
    public float ReloadTime;


    [Header("Bullet Data"), Space(10)]
    public BulletData magazine;


    public override bool IsReloading() { return isReloading; }
    bool isReloading;

    [Header("Instantate Point"),Space(10)]
    public Transform firePoint;
    public Transform rejectPoint;
    public Transform effectPoint;

    [Header("Resource Path"), Space(10)]
    public string BulletName;
    public string RejectName;
    public string FireEffectName;

    public virtual void FireEvent() { }
    public virtual void ReloadEvent(float x) { }

    public override bool IsGUN() => true; 
    public override float ReloadingP() => ReloadCnt;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }
    
    void Update()
    {
        if (isReloading)
        {
            ReloadCnt += Time.deltaTime;
            if (ReloadCnt > ReloadTime)
            {
                ReloadCnt = 0;
                magazine.Now = magazine.Max;
                isReloading = false;
            }
        }
        else if (RELOAD)
        {
            if (magazine.Now < magazine.Max)
            {
                isReloading = true;
                source.PlayOneShot(reloadSe);
            }
        }
        else if (gunType == GunType.SemiAuto && FIRE_DOWN) FIRE(); 
        else if ((gunType == GunType.FullAuto))
        {
            FireCnt += Time.deltaTime;
            if (FIRE_PRESS)
            {
                if (FireCnt >= FullAutoFireInterval)
                {
                    FireCnt = 0;
                    FIRE();
                }
            }
        }


    }





    //発射
    void FIRE()
    {
        if (magazine.Now > 0)
        {
            Instantiate(Resources.Load(RejectName), rejectPoint.position, rejectPoint.rotation);
            Instantiate(Resources.Load(FireEffectName), effectPoint.position, effectPoint.rotation);
            Instantiate(Resources.Load(BulletName), firePoint.position, firePoint.rotation);
            source.PlayOneShot(fireSe); magazine.Now--;
        }
    }



    private void OnValidate()
    {
        firePoint = SetChild(firePoint, "FirePoint");
        rejectPoint = SetChild(rejectPoint, "RejectPoint");
        effectPoint = SetChild(effectPoint, "EffectPoint");

        magazine.Update(); 
    }  

    public Transform SetChild(Transform t, string names)
    {
        if (t == null)
        {
            if (transform.Find(names) == null)
            {
                var x = new GameObject(names).transform;
                x.parent = transform;
                return x;
            }
            return transform.Find(names);
        }
        return t;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.07f);

        if (firePoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(firePoint.position, 0.02f);
            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.up);
        }

        if (rejectPoint != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(rejectPoint.position, 0.02f);
        }

        if (effectPoint != null)
        {
            Gizmos.color = new Color(1, 0.7f, 0.1f);
            Gizmos.DrawWireSphere(effectPoint.position, 0.02f);
        }
    }

}



[System.Serializable]
public class BulletData
{
    [SerializeField,Range(0,1000)]
    int now, max;
    
    public int Now { get => now; set => now = now < 0 ? 0 : (now > max ? max : now); }
    public int Max { get => max; set => max = max < 1 ? 1 : max; }

    public void Update()
    {
        Now = now;
        Max = max;
    }
}


public enum GunType
{
    SemiAuto,
    FullAuto
}



