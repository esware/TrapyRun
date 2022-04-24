using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesController : MonoBehaviour
{
    private Rigidbody rigid;
    public Rigidbody Rigid
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    
}
