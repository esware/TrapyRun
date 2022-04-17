using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New State",menuName ="EWGames/EnemiesAbility/Move")]
public class EnemyMove : StateData
{
    [SerializeField] private float speed = 10;
    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        EnemiesController controller = characterState.GetEnemiesController(animator);

        if (controller.isFall)
        {
            animator.SetBool("isFail", true);
        }
        else if(controller.Rigid.velocity.y <= -3f)
        {
            animator.SetBool("isFall", true);
        }
        else
        {
            if (controller.transform.position.x > 3)
            {
                controller.Rigid.MovePosition(controller.transform.position + Vector3.left * speed * Time.deltaTime);
            }
            else if (controller.transform.position.x < -3)
            {
                controller.Rigid.MovePosition(controller.transform.position + Vector3.right * speed * Time.deltaTime);
            }

            if (controller.transform.position.x <3 && controller.transform.position.x >-3)
            {
                controller.transform.rotation = Quaternion.identity;
                controller.Rigid.MovePosition(controller.transform.position + Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    

    
}
