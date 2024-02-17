using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    [SerializeField]
    private Transform  mainCameraTransform;

    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, mainCameraTransform.position.y,transform.position.z),Time.deltaTime * 15.0f);
        transform.position = new (transform.position.x,mainCameraTransform.position.y,transform.position.z);
    }
}
