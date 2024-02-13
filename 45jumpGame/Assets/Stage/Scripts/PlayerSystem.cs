using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField] 
    private ParamTable paramTable;

    [SerializeField]
    private Transform playerDirectionTransform;
    
    private Rigidbody rb;
    private Vector3 dirVector3 = new Vector3(1, 1, 0);
    private bool arrowDirectionisRight = true;
    private float arrowAngle;

    public float rotationSpeed = 30f;
    public float initSpeed = 10f;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        inputManager.OnDown += FirstDeparture;
    }

    private void Update()
    {
        
        
    }

    private void FirstDeparture()
    {
        Debug.Log("FirstDeparture");
        rb.velocity = dirVector3 * initSpeed;
        inputManager.OnDown -= FirstDeparture;
    }

    private void Departure()
    {
        Debug.Log("Departure");
        rb.velocity = dirVector3 * initSpeed;
        inputManager.OnUp -= Departure;
    }

    private void Stop()
    {
        Debug.Log("Stop");
        rb.velocity = Vector3.zero;
        RevertAngle();
        inputManager.OnUpdate -= Stop;
        inputManager.OnHold += Aim;
    }

    private void Aim()
    {
        Debug.Log("Aim");
        if(arrowDirectionisRight == true)
        {
            playerDirectionTransform.rotation = Quaternion.Euler(0f, 0f, 280f);
            inputManager.OnHold += RightSideDirectionRotate;
        }
        else
        {
            playerDirectionTransform.rotation = Quaternion.Euler(0f, 0f, 80f);
            inputManager.OnHold += LeftSideDirectionRotate;
        }
        inputManager.OnHold -= Aim;
        inputManager.OnUp += StopDirectionRotate;
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

    private void RevertAngle()
    {
        dirVector3 = new Vector3(-dirVector3.x, dirVector3.y, 0);
        arrowDirectionisRight = !arrowDirectionisRight;
    }

    private void RightSideDirectionRotate()
    {
        arrowAngle = rotationSpeed * Time.deltaTime;
        //Debug.Log(playerDirection.transform.rotation.eulerAngles.z);
        playerDirectionTransform.Rotate(0f, 0f, arrowAngle);
        if (playerDirectionTransform.rotation.eulerAngles.z > 350 || playerDirectionTransform.rotation.eulerAngles.z < 280)
        {
            rotationSpeed = -rotationSpeed;
            //Debug.Log("RightSideRevertRotation");
        }
    }

    private void LeftSideDirectionRotate()
    {
        arrowAngle = rotationSpeed * Time.deltaTime;
        //Debug.Log(playerDirection.transform.rotation.eulerAngles.z);
        playerDirectionTransform.Rotate(0f, 0f, arrowAngle);
        if (playerDirectionTransform.rotation.eulerAngles.z > 80 || playerDirectionTransform.rotation.eulerAngles.z < 10)
        {
            rotationSpeed = -rotationSpeed;
            //Debug.Log("LeftSideRevertRotation");
        }
    }

    private void StopDirectionRotate()
    {
        inputManager.OnHold -= RightSideDirectionRotate;
        inputManager.OnHold -= LeftSideDirectionRotate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RightSideWall") || other.gameObject.CompareTag("LeftSideWall"))
        {
            inputManager.OnUpdate += Stop;
        }
    }
}
