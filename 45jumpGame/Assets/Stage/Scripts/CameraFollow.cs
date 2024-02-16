using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private InputManager inputManager;

    public float cameraLerpRange = 1.0f;
    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }
    private void LateUpdate()
    {

        if(defaultPosition.y < playerTransform.position.y)
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x, playerTransform.position.y, transform.position.z),Time.deltaTime * cameraLerpRange);
    }
}