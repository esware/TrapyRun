using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour 
{
    private Rigidbody rigid;
    public Rigidbody Rigid => rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.IsFail = true;
            GetComponent<CapsuleCollider>().radius = .5f;
        }
    }
}

public enum AnimationTransition
{
    IsRunning,
    IsFalling,
    IsFailing,
    IsWinning,
    IsFindPlayer,
    
}

