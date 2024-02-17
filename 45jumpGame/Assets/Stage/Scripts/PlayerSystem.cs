using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField] 
    private ParamTable paramTable;

    [SerializeField]
    private GameObject playerDirection;

    [SerializeField]
    private Transform arrowObjectTransform;
    
    private Rigidbody rb;
    private Vector3 dirVector3 = Vector3.Normalize(new Vector3(1, 1, 0));
    private bool arrowDirectionisRight = true;
    private float arrowAngle;

    public float rotationSpeed = 30f;
    public float initSpeed = 10f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        inputManager.OnDown += FirstDeparture;
    }

    private void FirstDeparture()
    {
        //Debug.Log("FirstDeparture");
        rb.velocity = dirVector3 * initSpeed;
        inputManager.OnDown -= FirstDeparture;
    }

    private void Departure()
    {
        //Debug.Log("Departure");
        //Debug.Log("arrowTransForm.positon" + arrowObjectTransform.position);
        //Debug.Log("transform.postion" + transform.position);
        dirVector3 = Vector3.Normalize(arrowObjectTransform.position - transform.position);
        rb.velocity = dirVector3 * initSpeed;
        inputManager.OnUp -= Departure;
    }

    private void Stop()
    {
        //Debug.Log("Stop");
        rb.velocity = Vector3.zero;
        RevertDirection();
        inputManager.OnHold += Aim;
    }

    private void Aim()
    {
        //Debug.Log("Aim");
        if (arrowDirectionisRight)
        {
            playerDirection.transform.rotation = Quaternion.Euler(0f, 0f, 281f);
        }
        else
        {
            playerDirection.transform.rotation = Quaternion.Euler(0f, 0f, 79f);
        }
        inputManager.OnHold += ArrowRotate;
        inputManager.OnUp += StopArrowRotate;
        inputManager.OnHold -= Aim;
        inputManager.OnUp += Departure;
    }


    private void GetDamage()
    {

    }

    private void Missed()
    {

    }

    private void OpenMenu()
    {

    }

    private void RevertDirection()
    {
        //Debug.Log("RevertDirection");
        dirVector3 = new Vector3(-dirVector3.x, dirVector3.y, 0);
        arrowDirectionisRight = !arrowDirectionisRight;
    }

    private void RightSideArrowRotateRevert()
    {
        if (!(playerDirection.transform.rotation.eulerAngles.z <= 350f && playerDirection.transform.rotation.eulerAngles.z >= 280f))
        {
            //Debug.Log("RightSideRevertRotation");
            rotationSpeed = -rotationSpeed;
        }
    }

    private void LeftSideArrowRotateRevert()
    {
        if (!(playerDirection.transform.rotation.eulerAngles.z <= 80f && playerDirection.transform.rotation.eulerAngles.z >= 10f))
        {
            //Debug.Log("LeftSideRevertRotation");
            rotationSpeed = -rotationSpeed;
        }
    }


    //Clamp、あるいはMathf.Repeatを使った回転角度の制限もあることを考慮
    private void ArrowRotate()
    {
        Debug.Log(playerDirection.transform.rotation.eulerAngles.z);
        if (arrowDirectionisRight)
        {
            RightSideArrowRotateRevert();
            playerDirection.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(playerDirection.transform.rotation.eulerAngles.z, 280f, 350f));
        }
        else
        {
            LeftSideArrowRotateRevert();
            playerDirection.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(playerDirection.transform.rotation.eulerAngles.z % 360f, 10f, 80f));
        }
        arrowAngle = rotationSpeed * Time.deltaTime;
        playerDirection.transform.Rotate(0f, 0f, arrowAngle);
    }

    private void StopArrowRotate()
    {
        inputManager.OnHold -= ArrowRotate;
        inputManager.OnUp -= StopArrowRotate;
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RightSideWall") || other.gameObject.CompareTag("LeftSideWall"))
        {
            Stop();
        }
    }
}
