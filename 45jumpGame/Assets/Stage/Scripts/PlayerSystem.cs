using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField] 
    private ParamTable paramTable;
    
    private Rigidbody2D rb2D;
    private float initSpeed = 1f;
    private Vector3 dir = new Vector3(1, 1, 0);

    public Vector2 pos { get; private set; }

    private void Awake()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        inputManager.OnClicked += StageStart;
    }

    private void FixedUpdate()
    {
        
    }

    private void StageStart()
    {
        Debug.Log("StageStart");
        rb2D.AddForce(dir);
        inputManager.OnClicked -= StageStart;
        inputManager.OnFixedUpdate += Proceeding;
    }

    private void Proceeding()
    {
        rb2D.AddForce(dir);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("RightSideWall") || collision.gameObject.CompareTag("LeftSideWall"))
        {

            RevertAngle();
        }
    }
}
