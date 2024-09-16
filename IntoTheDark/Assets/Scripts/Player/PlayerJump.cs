using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private PlayerMove move;

    private void OnEnable()
    {
        InputManager.Instance.AddActionListenner(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Jump"),
            Defines.InputDefines.ActionPoint.All,
            OnJump);
    }

    private void FixedUpdate()
    {
        if(move.IsGround == false)
        {
            Vector3 newVel = rigid.velocity;
            newVel.y -= status.FallingSpeed;
            rigid.velocity = newVel;
        }
    }

    private void OnDisable()
    {
        InputManager.Instance?.RemoveInputEventFunction(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Jump"),
            Defines.InputDefines.ActionPoint.All,
            OnJump);
    }

    private void OnJump(InputAction.CallbackContext _context)
    {
        if(move.IsGround)
        {
            rigid.AddForce(Vector3.up * status.JumpForce, ForceMode.Impulse);
        }
    }
}
