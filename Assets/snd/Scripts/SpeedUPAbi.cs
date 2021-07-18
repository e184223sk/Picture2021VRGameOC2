using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SpeedUPAbi :AbilitySuper
{
    private float _originSpeed;


    public SpeedUPAbi(float cooltime = 10f, float usabletime = 5f)
    {
        _coolTime = cooltime;
        _usableTime = usabletime;
    }

    public override void Effect(PlayerCtrler player)
    {
        

        _originSpeed = _player._speed;
         player._speed *= 5.0f;

    }

    public override void AntiEffect(PlayerCtrler player)
    {
         player._speed = _originSpeed;

    }
}

