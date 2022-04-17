using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    PlayerController controller;
    Vector3 distance;
    [SerializeField] private float smooth;
    [SerializeField] private GameObject confetti = null;

    private void Awake()
    {
        controller = FindObjectOfType<PlayerController>();
        distance = transform.position - controller.transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 targetPos = distance + controller.transform.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, smooth*Time.deltaTime);

        if (GameManager.Instance.isWin)
        {
            confetti.gameObject.SetActive(true);
        }
    }
}
