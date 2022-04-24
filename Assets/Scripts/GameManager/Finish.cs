using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.IsWin = true;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            UIManager.level++;
        }
    }
}
