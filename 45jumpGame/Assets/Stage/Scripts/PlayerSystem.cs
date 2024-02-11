using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField] 
    private ParamTable paramTable;
    
    private Rigidbody rb;
    public float initSpeed = 10f;
    private Vector3 dir = new Vector3(1, 1, 0);

    public Vector2 pos { get; private set; }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        inputManager.OnClicked += Departure;
    }

    private void Departure()
    {
        Debug.Log("Departure");
        rb.velocity = dir * initSpeed;
        //rb.AddForce(dir * initSpeed, ForceMode.VelocityChange);
        inputManager.OnClicked -= Departure;
    }

    private void Stop()
    {
        Debug.Log("Stop");
        //rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        rb.velocity = Vector3.zero;
        RevertAngle();
        inputManager.OnUpdate -= Stop;
        inputManager.OnClicked += Departure;
    }

    public void GetDamage()
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
        dir = new Vector3(-dir.x, dir.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RightSideWall") || other.gameObject.CompareTag("LeftSideWall"))
        {
            inputManager.OnUpdate += Stop;
        }
    }
}
