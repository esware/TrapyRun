namespace FSM
{
    public class TileGrounded : BaseState
    {
        protected readonly TileSM sm;

        protected TileGrounded(TileSM stateMachine) : base(stateMachine)
        {
            sm = (TileSM)this.stateMachine;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
        }
    }
}