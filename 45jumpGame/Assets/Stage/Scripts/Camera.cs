using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private InputManager inputManager;

    private Vector3 diff;

    private void Start()
    {
        diff = transform.position - playerPos.position;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x, playerPos.position.y + diff.y, transform.position.z),Time.deltaTime * 5.0f);
    }
}