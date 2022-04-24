using System;
using System.Threading;
using FSM.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

namespace FSM
{
    public class EnemySM :StateMachine
    {
        public enum EnemyType
        {
            NORMAL,
            SMART
        }
        [HideInInspector] public EnemiesController enemiesController;
        [HideInInspector] public Collider collider;
        [ShowIf("enemyType", EnemyType.SMART)] public NavMeshAgent agent;
        [ShowIf("enemyType", EnemyType.NORMAL)]public float Speed ;
        [ShowIf("enemyType", EnemyType.NORMAL)]public Rigidbody Rigid;
        [ShowIf("enemyType", EnemyType.NORMAL)]public Animator Animator;
        
        [HideInInspector] public PlayerController controller;
        public float EnemyDistance = 30;
        public EnemyType enemyType;
        public bool findCharacter = false;
        [HideInInspector] public EnemyIdle idleState;
        [HideInInspector] public EnemyMoving movingState;
        [HideInInspector] public EnemyFall fallingState;
        [HideInInspector] public FindCharacter findingCharacter;
        private void Awake()
        {
            collider = GetComponent<Collider>();
            idleState = new EnemyIdle(this);
            movingState = new EnemyMoving(this);
            fallingState = new EnemyFall(this);
            findingCharacter = new FindCharacter(this);
            controller = FindObjectOfType<PlayerController>();
            if (enemyType == EnemyType.SMART)
            {
                enemiesController = GetComponent<EnemiesController>();
            }
        }
        
        
        
        protected override BaseState GetInitialState()
        {
            return idleState;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                if (GetComponent<NavMeshAgent>())
                {
                    agent.enabled = false;
                }
            }
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                findCharacter = true;
            }
        }
    }
}