using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

public class Moving : Grounded
{
    public Moving(PlayerSM stateMachine) : base(stateMachine) { }

    // ReSharper disable Unity.PerformanceAnalysis
    public override void Enter()
    {
        sm.Rigid.useGravity = true;
        sm.Rigid.isKinematic = false;
        sm.Animator.SetBool(AnimationTransition.IsRunning.ToString(),true);
        base.Enter();
    }

    public override void UpdateLogic()
    {
        if (sm.Rigid.velocity.y <= -3f)
        {
            sm.ChangeState(sm.fallingState);
        }
        if (GameManager.Instance.IsFail)
        {
            sm.ChangeState(sm.failingState);
        }

        if (GameManager.Instance.IsWin)
        {
            sm.ChangeState(sm.winningState);
        }
    }
    public override void UpdatePhysics()
    {
        var movement = new Vector3(InputHandler.Instance.positionX, 0f, 1);
        sm.Rigid.MovePosition(sm.transform.position + movement * (sm.Speed * Time.deltaTime));
        sm.transform.rotation = Quaternion.Lerp(sm.transform.rotation, Quaternion.Euler(0, InputHandler.Instance.rotationY, 0), sm.Speed );
    }
}
