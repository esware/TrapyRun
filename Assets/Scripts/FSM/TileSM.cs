using System;
using System.Collections;
using System.Collections.Generic;
using FSM.States.TileStates;
using UnityEngine;
using UnityEngine.AI;

public class TileSM : StateMachine
{
    public Rigidbody Rigid;
    private IEnumerator coroutine;
    [HideInInspector] public TileIdle idleState;
    [HideInInspector] public TileMoving movingState;
    private NavMeshSurface surface;

    private void Awake()
    {
        idleState = new TileIdle(this);
        movingState = new TileMoving(this);
        
    }

    
    
    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Instance.IsStart )
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (!GameManager.Instance.IsFail)
                {
                    coroutine = GroundTimer(0.3f);
                    StartCoroutine(coroutine);
                }
            }
        }
    }
    
    IEnumerator GroundTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        Rigid.useGravity = true;
        Rigid.isKinematic = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        Color gameObjectColor = gameObject.GetComponent<MeshRenderer>().material.color;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObjectColor,Color.red,30f*Time.deltaTime);
        
    }
}
