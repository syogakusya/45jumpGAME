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
    public Vector2 pos { get; private set; }

    private void Awake()
    {
        rb2D = gameObject.AddComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void StageStart()
    {

    }

    private void Proceeding()
    {

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
}
