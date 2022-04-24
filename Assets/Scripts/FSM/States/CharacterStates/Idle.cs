using System;

namespace FSM.States.CharacterStates
{
    public class Idle : Grounded
    {
        public Idle(PlayerSM stateMachine) : base(stateMachine) { }

        public override void UpdateLogic()
        {
            if (InputHandler.Instance.isStart)
            {
                GameManager.Instance.IsStart = true;
                stateMachine.ChangeState(sm.movingState);          
            }
        }

    }
}
