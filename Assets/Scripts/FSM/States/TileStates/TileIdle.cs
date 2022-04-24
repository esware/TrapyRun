namespace FSM.States.TileStates
{
    public class TileIdle:TileGrounded
    {
        public TileIdle(TileSM stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            sm.Rigid.useGravity = false;
            sm.Rigid.isKinematic = true;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            if (InputHandler.Instance.isStart)
            {
                GameManager.Instance.IsStart = true;
                stateMachine.ChangeState(sm.movingState);          
            }
        }
    }
}