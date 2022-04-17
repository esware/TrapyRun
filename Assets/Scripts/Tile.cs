using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Rigidbody rigid;
    private IEnumerator coroutine;

    #region Init Methods
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigid.useGravity = false;
        rigid.isKinematic = true;
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!GameManager.Instance.isFail)
            {
                coroutine = GroundTimer(0.3f);
                StartCoroutine(coroutine);
            } 
        }
    }

    private void Update()
    {
        if(transform.localPosition.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator GroundTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        rigid.useGravity = true;
        rigid.isKinematic = false;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        Color gameObjectColor = gameObject.GetComponent<MeshRenderer>().material.color;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(gameObjectColor,Color.red,30f*Time.deltaTime);
        
    }
}
