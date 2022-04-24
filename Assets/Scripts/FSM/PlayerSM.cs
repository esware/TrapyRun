using FSM.States.CharacterStates;
using UnityEngine;

namespace FSM
{
    public class PlayerSM : StateMachine
    {
        public float Speed;
        public Rigidbody Rigid;
        public Animator Animator;
        public Collider collider;
        [HideInInspector]
        public Idle idleState;
        [HideInInspector]
        public Moving movingState;
        [HideInInspector] public Win winningState;
        [HideInInspector] public Fall fallingState;
        [HideInInspector] public Fail failingState;

        private void Awake()
        {
            idleState = new Idle(this);
            movingState = new Moving(this);
            fallingState = new Fall(this);
            winningState = new Win(this);
            failingState = new Fail(this);
        }

        protected override BaseState GetInitialState()
        {
            return idleState;
        }
    }
}
