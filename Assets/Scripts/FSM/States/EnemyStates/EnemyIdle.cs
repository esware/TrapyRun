using System.Collections;
using System.Collections.Generic;
using FSM.States.EnemyStates;
using Unity.Mathematics;
using UnityEngine;

namespace FSM
{
    public class EnemyIdle : EnemyGrounded
    {
        public EnemyIdle(EnemySM stateMachine):base (stateMachine){}
        private bool isRunning = false;
        public override void UpdateLogic()
        {
            if (GameManager.Instance.IsStart)
            {
                if(isRunning)
                    enemySm.ChangeState(enemySm.movingState);
            }
        }

        public override void UpdatePhysics()
        {
            if (Vector3.Distance(enemySm.controller.transform.position,enemySm.transform.position ) < enemySm.EnemyDistance)
            {
                isRunning = true;
            }
        }
    }
}
