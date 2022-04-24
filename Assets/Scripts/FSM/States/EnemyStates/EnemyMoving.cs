using UnityEngine;
using System;
using Unity.Mathematics;
using UnityEngine.AI;


namespace FSM.States.EnemyStates
{
    public class EnemyMoving : EnemyGrounded
    {
        private Vector3 movement;
        private float yPos = 0;
        public EnemyMoving(EnemySM stateMachine):base (stateMachine){}
        
        public override void Enter()
        {
            enemySm.Rigid.useGravity = true;
            enemySm.Rigid.isKinematic = false;
            enemySm.Animator.SetBool(AnimationTransition.IsRunning.ToString(),true);
        }

        public override void UpdateLogic()
        {
            if(enemySm.Rigid.velocity.y < -1f)
                enemySm.ChangeState(enemySm.fallingState);
            if (enemySm.findCharacter)
            {
                enemySm.ChangeState(enemySm.findingCharacter);
            }
        }

        public override void UpdatePhysics()
        {
            enemySm.Animator.SetBool(AnimationTransition.IsRunning.ToString(),true);
            switch (enemySm.enemyType)
            {
                case EnemySM.EnemyType.SMART:
                    if (enemySm.agent.enabled)
                    {
                        enemySm.agent.destination = enemySm.controller.transform.position;
                    }
                    break;
                case EnemySM.EnemyType.NORMAL:
                    if (enemySm.transform.position.x > 3.2f)
                    {
                        enemySm.transform.rotation = Quaternion.Euler(0,-90,0);
                    }else if (enemySm.transform.position.x < -3.1f)
                    {
                        enemySm.transform.rotation = Quaternion.Euler(0,90,0);
                    }
                    else if(enemySm.transform.position.x < -3 ||enemySm.transform.position.x > 3)
                    {
                        enemySm.transform.rotation = quaternion.identity;
                    }
                    movement = enemySm.transform.forward;
                    enemySm.Rigid.MovePosition(enemySm.transform.position + movement * (enemySm.Speed * Time.deltaTime));
                    break;
            }
        }
        
        
    }
}