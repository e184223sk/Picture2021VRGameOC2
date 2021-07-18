using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
class JumpUPAbi : AbilitySuper
{

    private float _originJumpForce;

    public override  void Effect(PlayerCtrler player)
    {
        _originJumpForce =  player._jumpForce;
         player._jumpForce *= 5.0f;
    }

    public override void AntiEffect(PlayerCtrler player)
    {
         player._jumpForce = _originJumpForce;
    }


}

