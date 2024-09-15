using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Defines;
using System;
using static Defines.InputDefines;

public class InputManager :SingletonBehaviour<InputManager>
{
    [SerializeField] private PlayerInput playerInput;

    public override void Awake()
    {
        base.Init();
        DontDestroyOnLoad(gameObject);
    }

    public void AddActionListenner(InputDefines.InputActionName _actionName, InputDefines.ActionPoint _actionPoint, Action<InputAction.CallbackContext> _callbackContext)
    {
        var inputAction = GetInputAction(_actionName);
        try
        {
            switch (_actionPoint)
            {
                case InputDefines.ActionPoint.IsStarted:
                    inputAction.started += _callbackContext;
                    break;
                case InputDefines.ActionPoint.IsCanceled:
                    inputAction.canceled += _callbackContext;
                    break;
                case InputDefines.ActionPoint.IsPerformed:
                    inputAction.performed += _callbackContext;
                    break;
                case InputDefines.ActionPoint.All:
                    inputAction.started += _callbackContext;
                    inputAction.canceled += _callbackContext;
                    inputAction.performed += _callbackContext;
                    break;
            }
        }
        catch (System.Exception ex)
        {
            Logger.Instance.LogError(ex.Message);
        }
    }

    public bool RemoveInputEventFunction(InputDefines.InputActionName actionName, InputDefines.ActionPoint actionPoint, Action<InputAction.CallbackContext> instance)
    {
        //특정 이벤트에 붙어있는 특정 함수만 등록 해제
        InputAction inputAction = GetInputAction(actionName);
        if (inputAction == null)
            return false;

        switch (actionPoint)
        {
            case InputDefines.ActionPoint.IsStarted:
                inputAction.started -= instance;
                break;
            case InputDefines.ActionPoint.IsPerformed:
                inputAction.performed -= instance;
                break;
            case InputDefines.ActionPoint.IsCanceled:
                inputAction.canceled -= instance;
                break;
            case InputDefines.ActionPoint.All:
                inputAction.started -= instance;
                inputAction.performed -= instance;
                inputAction.canceled -= instance;
                break;
        }

        return true;
    }

    public void RemoveAllEventFunction(InputDefines.InputActionName inputPoint)
    {
        //모든 액션 네임 아니고 특정 액션 네임 받아오면
        //거기에 붙어있는 함수 다 제거
        InputAction inputAction = GetInputAction(inputPoint);
        if (inputAction == null)
            return;

        inputAction.Reset();
    }

    public void EnableAction(InputDefines.InputActionName actionPoint, bool isEnable)
    {
        InputAction inputAction = GetInputAction(actionPoint);
        if (isEnable)
        {
            inputAction.Enable();
        }
        else
        {
            inputAction.Disable();
        }
    }

    public void EnableActionMap(InputDefines.ActionMapType mapName, bool isEnable)
    {
        InputActionMap map = playerInput.actions.FindActionMap(mapName.ToString());
        if (isEnable)
        {
            map.Enable();
        }
        else
        {
            map.Disable();
        }
    }


    private InputAction GetInputAction(InputDefines.InputActionName _actionName)
    {
        try
        {
            return playerInput?.actions.FindActionMap(_actionName.MapType.ToString())?.FindAction(_actionName.ActionName);
        }
        catch (System.Exception e)
        {
            Logger.Instance.LogError(e.Message);
        }
        return null;
    }
}
