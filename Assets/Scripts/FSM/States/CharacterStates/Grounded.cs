using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class Grounded : BaseState
{
    protected readonly PlayerSM sm;

    protected Grounded(PlayerSM stateMachine) : base(stateMachine)
    {
        sm = (PlayerSM)this.stateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

}
