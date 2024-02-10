using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);
    }
}