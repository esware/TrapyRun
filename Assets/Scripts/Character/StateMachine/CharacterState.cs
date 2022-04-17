using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : StateMachineBehaviour
{
    public List<StateData> abilityData = new List<StateData>();

    public void UpdateAll(CharacterState characterState ,Animator animator)
    {
        foreach(StateData d in abilityData)
        {
            d.UpdateAbility(characterState, animator);
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateAll(this, animator);
    }

    private PlayerController controller;
    public PlayerController GetCharacterControl(Animator animator)
    {
        if(controller == null)
        {
            controller = animator.GetComponentInParent<PlayerController>();
        }
        return controller;
    }

    private EnemiesController enemyController;
    public EnemiesController GetEnemiesController(Animator animator)
    {
        if(enemyController == null)
        {
            enemyController = animator.GetComponentInParent<EnemiesController>();
        }
        return enemyController;
    }
}
