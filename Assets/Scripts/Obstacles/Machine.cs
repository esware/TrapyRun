using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [Range(0,1)]
    [SerializeField] private int spawnRot;
    private void Update()
    {
        if(spawnRot == 1)
        {
            transform.Rotate(0, -3, 0, Space.Self);
        }
        else
        {
            transform.Rotate(0, 3, 0, Space.Self);
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
