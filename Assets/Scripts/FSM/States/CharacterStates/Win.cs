using UnityEngine;

namespace FSM.States.CharacterStates
{
    public class Win : Grounded
    {
        public Win(PlayerSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            sm.Rigid.useGravity = false;
            sm.collider.isTrigger = true;
        }
        public override void UpdatePhysics()
        {
            sm.Animator.SetBool(AnimationTransition.IsWinning.ToString(), true);
        }
    }
}