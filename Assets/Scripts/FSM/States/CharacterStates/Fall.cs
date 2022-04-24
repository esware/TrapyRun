namespace FSM.States.CharacterStates
{
    public class Fall : Grounded
    {
        public Fall(PlayerSM stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            GameManager.Instance.IsFail = true;
        }

        public override void UpdatePhysics()
        {
            sm.Animator.SetBool(AnimationTransition.IsFalling.ToString(), true);
        }
        
    }
}