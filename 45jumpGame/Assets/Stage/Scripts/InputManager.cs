using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public event UnityAction OnClicked, OnOpenedMenu, OnUpdate, OnFixedUpdate;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            OnClicked?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOpenedMenu?.Invoke();
        }

        OnUpdate?.Invoke();   
    }

    private void FixedUpdate()
    {
        OnFixedUpdate?.Invoke();
    }
}
