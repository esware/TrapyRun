using UnityEngine;
using UnityEngine.AI;

namespace FSM.States.EnemyStates
{
    public class EnemyFall:EnemyGrounded
    {
        public EnemyFall(EnemySM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            if (enemySm.enemyType == EnemySM.EnemyType.SMART)
            {
                enemySm.agent.enabled = false;
            }
            enemySm.GetComponent<Collider>().isTrigger = true;
        }
        public override void UpdatePhysics()
        {
            enemySm.Animator.SetBool(AnimationTransition.IsFalling.ToString(), true);
        }
    }
}