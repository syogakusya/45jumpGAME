using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, playerPos.position.y, transform.position.z), Time.deltaTime * 5.0f);
    }
}