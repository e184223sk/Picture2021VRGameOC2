using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public static bool _SpeedUPEnable = false;

    public static float _SpeedRate = 3.0f;

    public static bool _JumpUPEnable = false;

    public static float _JumpRate = 3.0f;

    public static bool _FlyEnable = false;

    public bool _flyable = false;


    public static bool _IsLobby = false;

    //クールタイムを保持する変数
    [SerializeField, Range(10, 60)]
    public float _coolTime;

    //使用可能時間を保持する変数
    [SerializeField, Range(3, 10)]
    public float _usableTime;

    //実際にクールタイムをカウント(減らす)する変数
    public static float _remainCoolTime;

    //実際に使用時間をカウント(減らす)する変数
    public float _remainUsableTime;

    //使用中かどうか
    public bool _IsUsing = false;

    //使用可能かどうか
    public bool _IsUsable = true;



    public float SpeedUPUsableTime;

    public float JumpUPUsableTime;
    public float JetpackUsableTime;



    PlayerCtrler _player;

    public void Start()
    {
        _player = GetComponent<PlayerCtrler>();
        _remainUsableTime = _usableTime;
        _remainCoolTime = _coolTime;
        _SpeedUPEnable = true;
    }

    // Update is called once per frame
    void Update()
    {
        UseAbility();
    }

    public void UseAbility()
    {

        if (_IsLobby) return;

        //アビリティON
        if (_IsUsable && VRInput.LGrip)
        {
            _IsUsable = false;
            _IsUsing = true;
            Debug.Log("アビリティ発動！");
            //アビリティ発動
            if (_SpeedUPEnable) { _player._speed *= _SpeedRate; _usableTime = SpeedUPUsableTime; }
            if (_JumpUPEnable) { _player._jumpForce *= _JumpRate; _usableTime = JumpUPUsableTime; }
            if (_FlyEnable) { _flyable = true; _usableTime = JetpackUsableTime; }
        }


        //アビリティが使用可能ならここから先はいらん！
        if (_IsUsable) return;

        //使用中の処理
        if (_IsUsing)
        { 
            if (_flyable && VRInput.RGripPress)
            {
                _player._rigidbody.AddForce(Vector3.up * _player._jumpForce / 100, ForceMode.Acceleration);
            }
            //効果時間中
            _remainUsableTime -= Time.deltaTime;

            Debug.Log("Ability Using!");
            if (_remainUsableTime < 0)
            {
                _IsUsing = false;
                _remainUsableTime = _usableTime;

                //アビリティ無効化
                if (_SpeedUPEnable) _player._speed /= _SpeedRate;
                if (_JumpUPEnable) _player._jumpForce /= _JumpRate;
                if (_FlyEnable) _flyable = false;
            }
        }
        else
        {
            //クールタイム中
            _remainCoolTime -= Time.deltaTime;

            if (_remainCoolTime < 0)
            {
                _remainCoolTime = _coolTime;
                _IsUsable = true;

                Debug.Log("クールタイム終了！");
            }
        }
    }
}
