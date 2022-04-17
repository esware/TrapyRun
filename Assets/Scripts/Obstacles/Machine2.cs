using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine2 : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private int Rot;
    [Range(1,10)]
    [SerializeField] private int speed;
    Vector3 direction;

    private void Awake()
    {
        direction = Vector3.left;
    }

    private void FixedUpdate()
    {
        if (Rot == 1)
        {
            transform.Translate(direction* speed*Time.deltaTime);
        }
        else
        {
            transform.Translate(-direction * speed* Time.deltaTime);
        }

        if(transform.position.x > 8)
        {
            direction *= -1;
        }
        else if(transform.position.x < -8)
        {
            direction *= -1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 dir = other.transform.position - transform.position;
        dir.Normalize();
        float strength = 2500;
        other.gameObject.GetComponent<Rigidbody>().AddForce(dir * strength, ForceMode.Acceleration);

    }
}
