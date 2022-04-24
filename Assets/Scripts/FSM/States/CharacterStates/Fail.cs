namespace FSM.States.CharacterStates
{
    public class Fail : Grounded
    {
        public Fail(PlayerSM stateMachine) : base(stateMachine)
        {
        }
        
        public override void UpdatePhysics()
        {
            sm.Animator.SetBool(AnimationTransition.IsFailing.ToString(), true);
        }
    }
}