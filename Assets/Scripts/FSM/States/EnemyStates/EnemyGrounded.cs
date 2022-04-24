namespace FSM
{
    public class EnemyGrounded :BaseState
    {
        protected readonly EnemySM enemySm;

        protected EnemyGrounded(EnemySM stateMachine) : base(stateMachine)
        {
            enemySm = (EnemySM) this.stateMachine;
        }

    }
}