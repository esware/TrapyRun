using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New State",menuName ="EWGames/AbilityData/Idle")]
public class Idle : StateData
{
    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        PlayerController controller = characterState.GetCharacterControl(animator);

        if (InputHandler.Instance.isStart)
        {
            controller.Rigid.useGravity = true;
            animator.SetBool("isRunning", true);
            GameManager.Instance.isStart = true;
        }
    }
}
