using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    private bool isHolded = false;
    public event UnityAction OnHold, OnUp, OnDown, OnOpenedMenu, OnUpdate, OnFixedUpdate;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("OnDown");
            OnDown?.Invoke();
        }
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("OnUp");
            OnUp?.Invoke();
            isHolded = false;
        }
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if(isHolded == false)
            {
                Debug.Log("OnHold");
                isHolded = true;
            }
            OnHold?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("OnEscapeDown");
            OnOpenedMenu?.Invoke();
        }

        OnUpdate?.Invoke();   
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}
