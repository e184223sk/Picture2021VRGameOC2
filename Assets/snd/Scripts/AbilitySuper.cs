using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitySuper : MonoBehaviour
{
    
    public PlayerCtrler _player;

    public bool _Usable = true;

    public bool _IsUsing = false;

    public float _usableTime;

    public float _coolTime;

    public float _remainTime ;

    public float _remainCoolTime;

    /// <summary>
    /// クールタイムが発生していない時は 0 を返す 
    /// </summary>
    /// <returns></returns>
    public float GetCoolTime() {
        return _remainCoolTime == _coolTime ? 0 : _remainCoolTime;
    }
    

    public delegate void EffectDelegate(PlayerCtrler player);
    public delegate void AntiEffectDelegate(PlayerCtrler player);

    protected EffectDelegate _effect;
    protected AntiEffectDelegate _antiEffect;

    public abstract void Effect(PlayerCtrler player);
    public abstract void AntiEffect(PlayerCtrler player);


    public void Start()
    {
        _Usable = true;
        _IsUsing = false;
        _usableTime = 5f;
        _coolTime = 10f;
        _remainTime = _usableTime;
        _remainCoolTime = _coolTime;
        

    }


    public  void UseAbility()
    {
        if(_Usable && VRInput.LGrip)
        {
            Debug.Log("アビリティ発動！");
            _IsUsing = true;
            _Usable = false;
            _effect(_player);
        }

        if (_IsUsing)
        {
            _remainTime -= Time.deltaTime;
            if(_remainTime < 0)
            {
                _remainTime = _usableTime;
                _IsUsing = false;
                _antiEffect(_player);
            }

        }
        else
        {

            _remainCoolTime -= Time.deltaTime;
            if(_remainCoolTime < 0)
            {
                _remainCoolTime = _coolTime;
                _Usable = true;
            }

        }
    }

    public void ChangeAbility(AbilitySuper ability)
    {
        _effect = ability.Effect;
        _antiEffect = ability.AntiEffect;
    }

}


