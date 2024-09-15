using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputTest : MonoBehaviour
{
    public void Awake()
    {
        InputManager.Instance.AddActionListenner(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Move"),
            Defines.InputDefines.ActionPoint.All, 
            OnMove);
    }


    private void OnMove(InputAction.CallbackContext _context)
    {
        Logger.Instance.Log(_context.ReadValue<Vector2>().ToString());
    }
}
