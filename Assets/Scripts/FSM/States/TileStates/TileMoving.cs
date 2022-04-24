using UnityEngine;

namespace FSM.States.TileStates
{
    public class TileMoving : TileGrounded
    {
        public TileMoving(TileSM stateMachine):base(stateMachine){}

        public override void Enter()
        {
            
        }

        public override void UpdatePhysics()
        {
            if (sm.transform.position.y < -10)
            {
                sm.gameObject.SetActive(false);
            }
        }
    }
}