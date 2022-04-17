using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "EWGames/EnemiesAbility/Idle")]
public class EnemyIdle : StateData
{
    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        if (InputHandler.Instance.isStart)
        {
            animator.SetBool("isRunning", true);
        }        
    }
}
