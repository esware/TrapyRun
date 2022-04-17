using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New State",menuName ="EWGames/AbilityData/Move")]
public class Move : StateData
{
    [SerializeField] private float speed;
    private Vector3 movement;
    public override void UpdateAbility(CharacterState characterState, Animator animator)
    {
        PlayerController controller = characterState.GetCharacterControl(animator);

        if(controller.Rigid.velocity.y <= -1f)
        {
            controller.Rigid.AddForce(speed * Vector3.forward*Time.deltaTime);
            animator.SetBool("isFall", true);
            GameManager.Instance.isFail = true;
        }
        else if (GameManager.Instance.isFail)
        {
            animator.SetBool("isFail", true);
        }
        else if (GameManager.Instance.isWin)
        {
            animator.SetBool("isWin", true);
            controller.Rigid.useGravity = false;
            controller.GetComponent<CapsuleCollider>().isTrigger = true;
        }
        else
        {
            movement = new Vector3(InputHandler.Instance.positionX, 0f, 1);
            controller.Rigid.MovePosition(controller.transform.position + movement * speed * Time.deltaTime);
            controller.transform.rotation = Quaternion.Euler(0, InputHandler.Instance.rotationY, 0);
        }
    }
}
