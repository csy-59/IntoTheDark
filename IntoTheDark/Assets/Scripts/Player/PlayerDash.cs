using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private PlayerStatus status;
    [SerializeField] private PlayerMove move;

    private WaitForSeconds waitForDashEnd;
    private Vector3 dashDirection;

    private void Start()
    {
        status.Speed = status.NormalSpeed;
        waitForDashEnd = new WaitForSeconds(status.DashTime);
    }

    private void OnEnable()
    {

        InputManager.Instance.AddActionListenner(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Dash"),
            Defines.InputDefines.ActionPoint.IsStarted,
            OnDash);
    }

    private void FixedUpdate()
    {
        if ((status.IsDashing) == true)
        {
            rigid.velocity = dashDirection;
        }
        rigid.velocity *= 0.5f;
    }

    private void OnDash(InputAction.CallbackContext _context)
    {
        status.IsDashing = true;

        Vector3 moveDir = move.MoveDirection;
        if (moveDir != Vector3.zero)
        {
            dashDirection = moveDir.normalized * status.DashSpeed;
            dashDirection = transform.TransformDirection(dashDirection);
        }
        else
        {
            dashDirection = rigid.transform.forward * status.DashSpeed;
        }
        dashDirection.y = 0f;

        rigid.velocity = Vector3.zero;
        StartCoroutine(StopDashing());
    }

    private IEnumerator StopDashing()
    {
        yield return waitForDashEnd;
        status.IsDashing = false;
        rigid.velocity = Vector3.zero;
        Logger.Instance.Log("End");
    }
}
