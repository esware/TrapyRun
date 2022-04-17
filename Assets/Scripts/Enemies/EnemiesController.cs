using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public bool isFall = false;
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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.isFail = true;
            isFall = true;
        }
    }
}
