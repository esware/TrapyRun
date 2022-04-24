using UnityEngine;
using UnityEngine.AI;

namespace FSM.States.EnemyStates
{
    public class FindCharacter:EnemyGrounded
    {
        public FindCharacter(EnemySM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (enemySm.agent.enabled)
            {
                enemySm.agent.enabled = false;
            }
            enemySm.Animator.SetBool(AnimationTransition.IsFindPlayer.ToString(),true);
            enemySm.collider.isTrigger = true;
            enemySm.Rigid.freezeRotation = true;
            enemySm.Rigid.isKinematic = true;
            enemySm.controller.Rigid.isKinematic = true;

        }
    }
}