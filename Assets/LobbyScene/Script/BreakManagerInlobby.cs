using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakManagerInlobby : MonoBehaviour
{
    public static int rTotal = 0;                       //objectの総数
    public static int rBreakobj = 0;                    //破壊処理が入ったobjectの個数。あとstaticは情報共有してる！
    public bool IsBreak = false;
    public Vector3 s;                                  //objectの初期座標
    Vector3 n;                                  //現在のobject座標

    // Start is called before the first frame update
    void Start()
    {
        s = transform.position;
        rTotal++;
    }

    // Update is called once per frame
    public void Update()
    {
        if (IsBreak)return;
        n = transform.position;
        if ((s.x - n.x > 2 || s.x - n.x < -2 || s.y - n.y > 5 || s.y - n.y < -5 || s.z - n.z > 2 || s.z - n.z < -2))
        {
            rBreakobj++;
            IsBreak = true;
            Destroy(this);
        }
    }
}
